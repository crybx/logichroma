﻿using AutoMapper;
using Logichroma.Areas.Game.Models.DataRepositoryInterfaces;
using Logichroma.Areas.Game.Models.GameModels;
using Logichroma.Database;
using Logichroma.Extensions;
using Logichroma.GameEngine;
using Logichroma.GameEngine.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Logichroma.Areas.Game.Models.DataRepositories
{
    public class GameRepository : IGameRepository
    {
        private readonly LogichromaDbEntities _db = new LogichromaDbEntities();

        public GameModel GetGame(int gameId)
        {
            var game = _db.Games.FirstOrDefault(x => x.Id == gameId);
            var gameModel = Mapper.Map<Database.Game, GameModel>(game);
            return gameModel;
        }

        public List<GameModel> GetActiveGames()
        {
            var aborted = GameEngine.Enums.GameStatus.Aborted.ToString();
            var complete = GameEngine.Enums.GameStatus.Complete.ToString();

            var games = _db.Games
                .Where(x => !x.GameStatuses.Any(s => s.Status == aborted || s.Status == complete))
                .ToList();

            var gameModels = Mapper.Map<List<Database.Game>, List<GameModel>>(games);

            return gameModels;
        }

        public bool IsGameNameAvailable(string name)
        {
            var nameAlreadyExists = _db.Games.Any(g => g.Name == name);
            return !nameAlreadyExists;
        }

        public GameModel AddGame(GameModel gameOptions)
        {
            var game = new Database.Game
            {
                Name = gameOptions.Name,
                DifficultyLvl = 1,
                CreateDateTime = DateTime.Now,
                HintTokens = 8,
                MisfireTokens = 3
            };

            _db.Games.Add(game);
            _db.SaveChanges();

            // Create the deck.
            var cardSuits = _db.CardSuits.ToList();
            var cardValues = _db.CardValues.ToList();
            var deck = GameMechanics.CreateGameDeck(cardSuits, cardValues, game.Id);

            // Save the deck in the database.
            _db.GameCards.AddRange(deck);
            _db.SaveChanges();

            var gameModel = Mapper.Map<Database.Game, GameModel>(game);
            return gameModel;
        }

        public void AddPlayerToGame(int gameId, string userId, string nickname, bool isOwner)
        {
            var player = new GamePlayer
            {
                GameId = gameId,
                PlayerId = userId,
                Nickname = nickname,
                IsGameOwner = isOwner
            };

            _db.GamePlayers.Add(player);
            _db.SaveChanges();
        }

        public void AddGameStatus(GameEngine.Enums.GameStatus gameStatus, int gameId)
        {
            var status = new Database.GameStatus
            {
                GameId = gameId,
                StatusChangeDateTime = DateTime.Now,
                Status = gameStatus.ToString()
            };

            _db.GameStatuses.Add(status);
            _db.SaveChanges();
        }
        
        public void SetPlayerOrder(int gameId)
        {
            var players = _db.GamePlayers.Where(x => x.GameId == gameId).ToList();

            players.Shuffle();

            // Set a random order for the players.
            for (var i = 0; i < players.Count; i++)
            {
                players[i].PlayerNumber = i;
                _db.Entry(players[i]).State = EntityState.Modified;
            }

            _db.SaveChanges();
        }

        public void DealStartingCards(int gameId)
        {
            var game = _db.Games.First(x => x.Id == gameId);
            var gameModel = Mapper.Map<Database.Game, GameModel>(game);
            var updatedGameModel = GameMechanics.DealStartingCards(gameModel);

            game.NextCard = updatedGameModel.NextCard;

            foreach (var cardModel in updatedGameModel.ChangedCards)
            {
                var card = game.GameCards.Single(x => x.Order == cardModel.Order);
                card.GamePlayer = game.GamePlayers.Single(x => x.GamePlayerId == cardModel.GamePlayerId);
                card.CardState = CardState.Hand.ToString();
            }

            _db.SaveChanges();
        }

        public void DiscardCard(int order, int gameId)
        {
            var game = _db.Games.First(x => x.Id == gameId);
            var card = game.GameCards.First(x => x.Order == order && x.CardState == CardState.Hand.ToString());
            
            dealReplacementCard(game, card);

            // Mark old card as discarded.
            card.DiscardOrder = game.GameCards.Count(x => x.CardState == CardState.Discard.ToString() || x.CardState == CardState.Misfire.ToString());
            card.CardState = CardState.Discard.ToString();

            // Replenish a hint token.
            if (game.HintTokens < 8) { game.HintTokens++; }

            advancePlayerTurn(game);

            _db.SaveChanges();
        }

        public List<CardModel> GetPlayerCards(int gameId, int playerId)
        {
            var cards = _db.GameCards.Where(x => x.GameId == gameId && x.GamePlayerId == playerId).ToList();
            var cardModels = Mapper.Map<List<GameCard>, List<CardModel>>(cards);
            return cardModels;
        }

        public void GivePlayerColorHint(int gameId, int playerId, int colorId)
        {
            var game = _db.Games.First(x => x.Id == gameId);

            if (game.HintTokens <= 0) return;

            // Remove a hint token.
            game.HintTokens--;

            // Reveal all player's cards of the chosen color.
            var cards = game.GameCards.Where(x => x.GamePlayerId == playerId);

            foreach (var card in cards)
            {
                if (card.CardSuitId == colorId)
                {
                    card.IsSuitRevealed = true;
                }
            }

            advancePlayerTurn(game);

            _db.SaveChanges();
        }

        public void GivePlayerNumberHint(int gameId, int playerId, int numberId)
        {
            var game = _db.Games.First(x => x.Id == gameId);

            if (game.HintTokens <= 0) return;

            // Remove a hint token.
            game.HintTokens--;

            // Reveal all player's cards of the chosen number value.
            var cards = game.GameCards.Where(x => x.GamePlayerId == playerId);

            foreach (var card in cards)
            {
                if (card.CardValueId == numberId)
                {
                    card.IsValueRevealed = true;
                }
            }
            
            advancePlayerTurn(game);

            _db.SaveChanges();
        }

        public void PlayCard(int order, int gameId)
        {
            var game = _db.Games.First(x => x.Id == gameId);
            var card = game.GameCards.First(x => x.Order == order);

            dealReplacementCard(game, card);

            // WHAT HAPPENED?! IS IT VALID CARD?! DO SPLOSIONS HAPPEN?
            var cardIsValid = isCardValidToPlay(game, card);

            if (cardIsValid)
            {
                // Mark card as played.
                card.CardState = CardState.Played.ToString();

                if (card.CardValue.FaceValue == 5 && game.HintTokens < 8)
                {
                    // A stack was completed. Replenish a hint token.
                    game.HintTokens++;
                }
            }
            else
            {
                // Mark card as misfired.
                card.CardState = CardState.Misfire.ToString();
                game.MisfireTokens--;

                //TODO: End game if misfire tokens reach zero. Need end game state/process first.
            }

            advancePlayerTurn(game);

            _db.SaveChanges();
        }

        public int GetCurrentPlayerNumber(int gameId)
        {
            var player = _db.Games.First(x => x.Id == gameId).CurrentPlayerNumber;
            return player;
        }
        
        /// <summary>
        /// Advances the game to the next player's turn.
        /// </summary>
        private void advancePlayerTurn(Database.Game game)
        {
            var nextPlayer = game.CurrentPlayerNumber + 1;
            game.CurrentPlayerNumber = nextPlayer < game.GamePlayers.Count ? nextPlayer : 0;
        }

        private void dealReplacementCard(Database.Game game, GameCard cardBeingReplaced)
        {
            var nextCard = game.GameCards.FirstOrDefault(x => x.Order == game.NextCard && x.CardState == CardState.Deck.ToString());

            // Deal player another card if any are left in the deck.
            if (nextCard != null)
            {
                nextCard.GamePlayer = cardBeingReplaced.GamePlayer;
                nextCard.CardState = CardState.Hand.ToString();
                game.NextCard++;
            }

            cardBeingReplaced.GamePlayerId = null;
        }

        private bool isCardValidToPlay(Database.Game game, GameCard card)
        {
            var isDuplicate = game.GameCards.Any(x =>
                x.CardState == CardState.Played.ToString()
                && x.CardSuit == card.CardSuit
                && x.CardValue == card.CardValue);

            if (isDuplicate) { return false; }

            // If there's no duplicate, and the card is a one, it's good.
            if (card.CardValue.FaceValue == 1) { return true; }

            var isPreReqPlayed = game.GameCards.Any(x =>
                x.CardState == CardState.Played.ToString()
                && x.CardSuit == card.CardSuit
                && x.CardValue.FaceValue == card.CardValue.FaceValue - 1);

            return isPreReqPlayed;
        }
    }
}
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
            var games = _db.Games
                .Where(x => !x.GameStatuses.Any(s => s.Status == GameEngine.Enums.GameStatus.Aborted.ToString() ||
                                                     s.Status == GameEngine.Enums.GameStatus.Complete.ToString()))
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
            var card = game.GameCards.First(x => x.Order == order);
            var nextCard = _db.GameCards.First(x => x.Order == game.NextCard);
            
            // Deal player another card if any are left in the deck.
            if (nextCard != null)
            {
                nextCard.GamePlayer = card.GamePlayer;
                nextCard.CardState = CardState.Hand.ToString();
                game.NextCard++;
            }
            
            // Remove dicard from player's hand and mark as discarded.
            card.CardState = CardState.Discard.ToString();
            card.GamePlayer = null;

            // Replenish a hint token.
            if (game.HintTokens < 8) { game.HintTokens++; }

            // Advance the game to the next player's turn.
            var nextPlayer = game.CurrentPlayerNumber + 1;
            game.CurrentPlayerNumber = nextPlayer < game.GamePlayers.Count ? nextPlayer : 0;
            
            _db.SaveChanges();
        }
    }
}
﻿using AutoMapper;
using Logichroma.Areas.Game.Models.DataRepositoryInterfaces;
using Logichroma.Areas.Game.Models.GameModels;
using Logichroma.Database;
using Logichroma.Extensions;
using Logichroma.GameEngine;
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
                .Where(x => !x.GameStatuses.Any(s => s.GameStatusType.Name == "Aborted" ||
                                                     s.GameStatusType.Name == "Completed"))
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
                NextCard = 0,
                StartDateTime = DateTime.Now
            };

            _db.Games.Add(game);
            _db.SaveChanges();

            // Create the deck.
            var colors = _db.Colors.ToList();
            var cardValues = _db.CardTypes.ToList();
            var inDeck = _db.CardStates.FirstOrDefault(x => x.Name == "Deck");
            var deck = GameMechanics.CreateGameDeck(colors, cardValues, inDeck, game.Id);

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

        public void AddGameStatus(string gameStatus, int gameId)
        {
            var status = new GameStatus
            {
                GameId = gameId,
                DateTime = DateTime.Now,
                GameStatusType = _db.GameStatusTypes.FirstOrDefault(x => x.Name == gameStatus)
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
            var game = _db.Games.FirstOrDefault(x => x.Id == gameId);

            if (game != null)
            {
                var inHand = _db.CardStates.FirstOrDefault(x => x.Name == "Hand");
                var updatedCards = GameMechanics.DealStartingCards(game, inHand);

                game.NextCard = updatedCards.Count - 1;

                foreach (var card in updatedCards)
                {
                    _db.Entry(card).State = EntityState.Modified;
                }

                _db.SaveChanges();
            }
        }
    }
}
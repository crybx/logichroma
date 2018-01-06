using AutoMapper;
using Logichroma.Extensions;
using Logichroma.Models.BusinessObjects;
using Logichroma.Models.Database;
using Logichroma.Models.DataRepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logichroma.Models.DataRepositories
{
    public class GameRepository : IGameRepository
    {
        private readonly LogichromaDbEntities _db = new LogichromaDbEntities();

        public List<GameModel> GetGames()
        {
            var games = _db.Games
                .Where(x => !x.GameStatuses.Any(s => s.GameStatusType.Name == "Aborted" ||
                                                     s.GameStatusType.Name == "Completed"))
                .ToList();

            var gameModels = Mapper.Map<List<Game>, List<GameModel>>(games);

            return gameModels;
        }

        public bool IsGameNameAvailable(string name)
        {
            var nameAlreadyExists = _db.Games.Any(g => g.Name == name);
            return !nameAlreadyExists;
        }

        public GameModel AddGame(GameModel gameOptions)
        {
            var game = new Game
            {
                Name = gameOptions.Name,
                DifficultyLvl = 1,
                NextCard = 0,
                StartDateTime = DateTime.Now
            };

            _db.Games.Add(game);
            _db.SaveChanges();

            createShuffledDeck(game);
            
            var gameModel = Mapper.Map<Game, GameModel>(game);
            return gameModel;
        }

        public void AddPlayerToGame(string userId, GameModel game)
        {
            var player = new GamePlayer
            {
                GameId = game.Id,
                PlayerId = userId
            };

            _db.GamePlayers.Add(player);
            _db.SaveChanges();
        }

        public void AddGameStatus(string gameStatus, GameModel game)
        {
            var status = new GameStatus
            {
                GameId = game.Id,
                DateTime = DateTime.Now,
                GameStatusType = _db.GameStatusTypes.FirstOrDefault(x => x.Name == gameStatus)
            };

            _db.GameStatuses.Add(status);
            _db.SaveChanges();
        }

        private void createShuffledDeck(Game game)
        {
            // Create the deck.
            var deck = createDeck();

            // Shuffle the deck.
            deck.Shuffle();

            // Record the order of the GameCard objects in the deck.
            for (var i = 0; i < deck.Count; i++)
            {
                deck[i].Game = game;
                deck[i].Order = i;
            }

            // Save the deck in the database.
            _db.GameCards.AddRange(deck);
            _db.SaveChanges();
        }

        private List<GameCard> createDeck()
        {
            var deck = new List<GameCard>();

            var colors = _db.Colors.ToList();
            var cardValues = _db.CardTypes.ToList();
            var cardStateInDeck = _db.CardStates.FirstOrDefault(x => x.Name == "Deck");
            
            foreach (var color in colors)
            {
                foreach (var cardValue in cardValues)
                {
                    for (var i = 0; i < cardValue.CountInDeck; i++)
                    {
                        var card = new GameCard
                        {
                            CardType = cardValue,
                            Color = color,
                            CardState = cardStateInDeck
                        };

                        deck.Add(card);
                    }
                }
            }

            return deck;
        }
    }
}
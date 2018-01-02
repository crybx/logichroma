using Logichroma.Extensions;
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

        public bool IsGameNameAvailable(string name)
        {
            var nameAlreadyExists = _db.Games.Any(g => g.Name == name);
            return !nameAlreadyExists;
        }

        public int AddGame(GameOptionsModel gameOptions)
        {
            var game = new Game
            {
                Name = gameOptions.GameTitle,
                DifficultyLvl = 1,
                NextCard = 0,
                StartDateTime = DateTime.Now
            };

            _db.Games.Add(game);
            _db.SaveChanges();

            createShuffledDeck(game);

            //TODO: create and save a game status of 'Created'

            return game.Id;
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
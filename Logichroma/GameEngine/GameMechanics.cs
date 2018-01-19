using Logichroma.Areas.Game.Models.GameModels;
using Logichroma.Areas.Game.Models.GameModels.ChildObjects;
using Logichroma.Database;
using Logichroma.Extensions;
using System.Collections.Generic;

namespace Logichroma.GameEngine
{
    public static class GameMechanics
    {
        public static GameModel DealStartingCards(GameModel game, CardStateModel inHand)
        {
            game.ChangedCards = new List<CardModel>();
            game.NextCard = 0;

            var players = game.GamePlayers;
            var handSize = 5;

            if (players.Count == 4 || players.Count == 5) { handSize = 4; }

            foreach (var player in players)
            {
                for (var i = 0; i < handSize; i++)
                {
                    var card = game.GameCards[game.NextCard];

                    card.GamePlayerId = player.GamePlayerId;
                    card.CardState = inHand;

                    game.ChangedCards.Add(card);
                    game.NextCard++;
                }
            }

            return game;
        }

        public static List<GameCard> CreateGameDeck(List<Color> colors, List<CardType> cardValues, CardState inDeck, int gameId)
        {
            var deck = new List<GameCard>();

            // Create all the cards in the deck.
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
                            CardState = inDeck
                        };

                        deck.Add(card);
                    }
                }
            }

            // Shuffle the deck.
            deck.Shuffle();

            // Record the shuffled order of cards in the deck.
            for (var i = 0; i < deck.Count; i++)
            {
                deck[i].GameId = gameId;
                deck[i].Order = i;
            }

            return deck;
        }
    }
}
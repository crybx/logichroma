using Logichroma.Extensions;
using Logichroma.Database;
using System.Collections.Generic;

namespace Logichroma.GameEngine
{
    public static class GameMechanics
    {
        public static void DealStartingCards()
        {

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
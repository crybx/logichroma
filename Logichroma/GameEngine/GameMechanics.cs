using Logichroma.Database;
using Logichroma.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Logichroma.GameEngine
{
    public static class GameMechanics
    {
        public static List<GameCard> DealStartingCards(Game game, CardState inHand)
        {
            var deck = game.GameCards.ToList();
            var players = game.GamePlayers;
            var updatedCards = new List<GameCard>();
            var nextCard = 0;
            var handSize = 5;

            if (players.Count == 4 || players.Count == 5) { handSize = 4; }

            foreach (var player in players)
            {
                for (var i = 0; i < handSize; i++)
                {
                    var card = deck[nextCard++];
                    card.GamePlayer = player;
                    card.CardState = inHand;
                    updatedCards.Add(card);
                }
            }

            return updatedCards;
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
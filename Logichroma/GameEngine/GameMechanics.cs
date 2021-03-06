﻿using Logichroma.Areas.Game.Models.GameModels;
using Logichroma.Areas.Game.Models.GameModels.ChildObjects;
using Logichroma.Database;
using Logichroma.Extensions;
using System.Collections.Generic;
using Logichroma.GameEngine.Enums;

namespace Logichroma.GameEngine
{
    public static class GameMechanics
    {
        public static GameModel DealStartingCards(GameModel game)
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
                    card.CardState = CardState.Hand.ToString();

                    game.ChangedCards.Add(card);
                    game.NextCard++;
                }
            }

            return game;
        }

        public static List<GameCard> CreateGameDeck(List<CardSuit> cardSuits, List<CardValue> cardValues, int gameId)
        {
            var deck = new List<GameCard>();

            // Create all the cards in the deck.
            foreach (var cardSuit in cardSuits)
            {
                foreach (var cardValue in cardValues)
                {
                    for (var i = 0; i < cardValue.CountInDeck; i++)
                    {
                        var card = new GameCard
                        {
                            CardValue = cardValue,
                            CardSuit = cardSuit,
                            CardState = CardState.Deck.ToString()
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
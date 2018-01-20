using Logichroma.Areas.Game.Models.GameModels;
using Logichroma.GameEngine.Enums;
using System.Linq;

namespace Logichroma.Areas.Game.Models
{
    public class GameDetailsViewModel
    {
        public GameModel Game { get; set; }

        public string CurrentUserId { get; set; }

        public string PlayerNickname { get; set; }

        public PlayerModel Player => Game?.GamePlayers?.FirstOrDefault(x => x.PlayerId == CurrentUserId);

        public PlayerModel CurrentPlayer => Game?.PlayersInOrder?[Game.CurrentPlayerNumber];

        public bool IsCurrentPlayer => Player == CurrentPlayer;

        public int PlayerCount => Game?.GamePlayers?.Count ?? 0;

        public int DeckCount => Game?.GameCards?.Count(x => x.CardState == CardState.Deck.ToString()) ?? 0;

        public bool CanJoinGame => Game.Status == "Created"
                                   && Player == null
                                   && PlayerCount < 5;

        public bool CanStartGame => Game.Status == "Created"
                                    && Player != null
                                    && Player.IsGameOwner
                                    && PlayerCount > 1;

        public bool CanPlayGame => Game.Status == "Started"
                                   && Player != null;
    }
}
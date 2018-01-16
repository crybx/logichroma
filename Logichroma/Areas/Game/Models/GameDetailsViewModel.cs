using Logichroma.Areas.Game.Models.GameObjectModels;
using System.Linq;

namespace Logichroma.Areas.Game.Models
{
    public class GameDetailsViewModel
    {
        public GameModel Game { get; set; }
        public string CurrentUserId { get; set; }
        public string PlayerNickname { get; set; }
        public PlayerModel CurrentPlayer => Game?.GamePlayers?.FirstOrDefault(x => x.PlayerId == CurrentUserId);
        public int PlayerCount => Game?.GamePlayers?.Count ?? 0;

        public bool CanJoinGame => Game.Status == "Created"
                                   && CurrentPlayer == null
                                   && PlayerCount < 5;

        public bool CanStartGame => Game.Status == "Created"
                                    && CurrentPlayer != null
                                    && CurrentPlayer.IsGameOwner
                                    && PlayerCount > 1;

        public bool CanPlayGame => Game.Status == "Started"
                                   && CurrentPlayer != null;
    }
}
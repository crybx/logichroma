using System.Linq;
using Logichroma.Models.BusinessObjects;
using Logichroma.Models.Database;

namespace Logichroma.Models
{
    public class GameDetailsViewModel
    {
        public GameModel Game { get; set; }
        public string CurrentUserId { get; set; }
        public string PlayerNickname { get; set; }
        public PlayerModel CurrentPlayer => Game?.GamePlayers?.FirstOrDefault(x => x.PlayerId == CurrentUserId);
        public int PlayerCount => Game?.GamePlayers?.Count ?? 0;
    }
}
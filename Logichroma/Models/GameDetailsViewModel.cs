using Logichroma.Models.BusinessObjects;

namespace Logichroma.Models
{
    public class GameDetailsViewModel
    {
        public GameModel Game { get; set; }
        public string CurrentUser { get; set; }
        public string PlayerNickname { get; set; }
    }
}
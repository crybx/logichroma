namespace Logichroma.Models.BusinessObjects
{
    public class PlayerModel
    {
        public int GamePlayerId { get; set; }
        public int GameId { get; set; }
        public string PlayerId { get; set; }
        public int PlayerNumber { get; set; }
        public string AspNetUserUserName { get; set; }
        public string UserName => AspNetUserUserName;
        public string Nickname;
    }
}
﻿
namespace Logichroma.Models.BusinessObjects
{
    public class PlayerModel
    {
        public int GameId { get; set; }
        public string PlayerId { get; set; }
        public string AspNetUserUserName { get; set; }
        public string UserName => AspNetUserUserName;
    }
}
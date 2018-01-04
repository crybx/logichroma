using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logichroma.Models.BusinessObjects
{
    public class GameModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DifficultyLevel { get; set; }
        public List<CardModel> GameCards { get; set; }
        public List<PlayerModel> GamePlayers { get; set; }
    }
}
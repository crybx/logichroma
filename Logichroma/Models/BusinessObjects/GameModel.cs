using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logichroma.Models.BusinessObjects
{
    public class GameModel
    {
        public int Id { get; set; }
        public int PlayerCount { get; set; }
        public int DifficultyLevel { get; set; }
        public string GameTitle { get; set; }
    }
}
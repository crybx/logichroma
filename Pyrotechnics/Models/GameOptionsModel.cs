using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pyrotechnics.Models
{
    public class GameOptionsModel
    {
        public int GameId { get; set; }
        public int PlayerCount { get; set; }
        public int DifficultyLevel { get; set; }
        public List<int> PlayerCounts = new List<int> {2, 3, 4, 5};

        [Required]
        public string GameTitle { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Logichroma.Models.GameObjectModels
{
    public class GameModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int DifficultyLevel { get; set; }
        public List<CardModel> GameCards { get; set; }
        public List<PlayerModel> GamePlayers { get; set; }
        public List<GameStatusModel> GameStatuses { get; set; }
        public string Status => GameStatuses?.OrderByDescending(x => x.DateTime).FirstOrDefault()?.Status;
    }
}
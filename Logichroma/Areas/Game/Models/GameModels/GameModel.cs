using Logichroma.Areas.Game.Models.GameModels.ChildObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Logichroma.Areas.Game.Models.GameModels
{
    public class GameModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int DifficultyLevel { get; set; }

        public DateTime CreateDateTime { get; set; }

        public int NextCard { get; set; }

        public int CurrentPlayerNumber { get; set; }

        public List<CardModel> GameCards { get; set; }
        
        public List<GameStatusModel> GameStatuses { get; set; }

        public List<PlayerModel> GamePlayers { get; set; }

        public string Status => GameStatuses?.OrderByDescending(x => x.StatusChangeDateTime).FirstOrDefault()?.Status;

        public List<PlayerModel> PlayersInOrder => GamePlayers?.OrderBy(x => x.PlayerNumber).ToList();

        public List<CardModel> ChangedCards { get; set; }

        public int HintTokens { get; set; }

        public int MisfireTokens { get; set; }
    }
}
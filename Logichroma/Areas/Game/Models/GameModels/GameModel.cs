using Logichroma.Areas.Game.Models.GameModels.ChildObjects;
using Logichroma.GameEngine.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Logichroma.Areas.Game.Models.GameModels
{
    public class GameModel
    {
        #region Part of Database Model

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

        public int HintTokens { get; set; }

        public int MisfireTokens { get; set; }

        #endregion

        public List<CardModel> ChangedCards { get; set; }

        // Derived stuff for convenience 

        #region Derived Properties for Convenience

        public List<CardModel> Discards =>
            GameCards.Where(x => x.CardState == CardState.Discard.ToString() || x.CardState == CardState.Misfire.ToString())
                     .OrderBy(x => x.DiscardOrder).ToList();

        public string Status => GameStatuses?.OrderByDescending(x => x.StatusChangeDateTime).FirstOrDefault()?.Status;

        public List<PlayerModel> PlayersInOrder => GamePlayers?.OrderBy(x => x.PlayerNumber).ToList();

        #endregion
    }
}
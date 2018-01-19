using System;

namespace Logichroma.Areas.Game.Models.GameModels.ChildObjects
{
    public class GameStatusModel
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }
        
        public GameStatusTypeModel GameStatusType { get; set; }

        public string Status => GameStatusType?.Name;
    }
}
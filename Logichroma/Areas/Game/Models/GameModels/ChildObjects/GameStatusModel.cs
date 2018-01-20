using System;

namespace Logichroma.Areas.Game.Models.GameModels.ChildObjects
{
    public class GameStatusModel
    {
        public int Id { get; set; }

        public string Status { get; set; }

        public DateTime StatusChangeDateTime { get; set; }

        public int GameId { get; set; }
    }
}
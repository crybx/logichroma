using System;

namespace Logichroma.Models.GameObjectModels
{
    public class GameStatusModel
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int GameStatusTypeId { get; set; }
        public string GameStatusTypeName { get; set; }
        public string Status => GameStatusTypeName;
    }
}
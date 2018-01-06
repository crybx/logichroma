using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logichroma.Models.BusinessObjects
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logichroma.Models.BusinessObjects
{
    public class CardModel
    {
        public int GameId { get; set; }
        public int Order { get; set; }
        public int CardTypeId { get; set; }
        public int CardTypeFaceValue { get; set; }
        public int ColorId { get; set; }
        public string ColorName { get; set; }
    }
}
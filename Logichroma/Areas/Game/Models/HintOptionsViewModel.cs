using Logichroma.Areas.Game.Models.GameModels;
using Logichroma.Areas.Game.Models.GameModels.ChildObjects;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Logichroma.Areas.Game.Models
{
    public class HintOptionsViewModel
    {
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public List<CardModel> Cards { get; set; }

        private List<CardSuitModel> CardSuits => 
            Cards.GroupBy(x => x.CardSuit.Name)
                 .Select(x => x.First())
                 .Select(x => x.CardSuit)
                 .ToList();

        private List<CardValueModel> CardValues => 
            Cards.GroupBy(x => x.CardValue.FaceValue)
                 .Select(x => x.First())
                 .Select(x => x.CardValue)
                 .OrderBy(x => x.FaceValue)
                 .ToList();
        
        public int SelectedNumberId { get; set; }

        public int SelectedColorId { get; set; }

        public SelectList Colors => new SelectList(CardSuits, "Id", "Name");

        public SelectList Numbers => new SelectList(CardValues, "Id", "FaceValue");
    }
}
using Logichroma.GameEngine;
using Logichroma.GameEngine.Enums;

namespace Logichroma.Areas.Game.Models.GameModels.ChildObjects
{
    public class ColorModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CardColor Color => ColorRules.GetCardColor(Name);

        public string BackgroundColor => ColorRules.GetBackgroundColor(Color);

        public string TextColor => ColorRules.GetTextColor(Color);
    }
}
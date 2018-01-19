using System;
using Logichroma.GameEngine.Enums;

namespace Logichroma.GameEngine
{
    public static class ColorRules
    {
        public static string GetColorName(CardColor color)
        {
            return Enum.GetName(typeof(CardColor), color);
        }

        public static CardColor GetCardColor(string colorName)
        {
            CardColor result;
            var isColor = Enum.TryParse(colorName, out result);
            return isColor ? result : CardColor.Wild;
        }

        public static string GetBackgroundColor(string colorName)
        {
            var cardColor = GetCardColor(colorName);
            return GetBackgroundColor(cardColor);
        }

        public static string GetBackgroundColor(CardColor color)
        {
            switch (color)
            {
                case CardColor.Blue:
                    return "#3961f5";

                case CardColor.Red:
                    return "#900f0f";

                case CardColor.Green:
                    return "#008000";

                case CardColor.Yellow:
                    return "yellow";

                case CardColor.White:
                    return "#fbf4f2";
                
                default:
                    return "gray";
            }
        }

        public static string GetTextColor(string colorName)
        {
            var cardColor = GetCardColor(colorName);
            return GetTextColor(cardColor);
        }

        public static string GetTextColor(CardColor color)
        {
            switch (color)
            {
                case CardColor.Blue:
                    return "white";

                case CardColor.Red:
                    return "#f1c7c7";

                case CardColor.Green:
                    return "#b4dcb8";

                case CardColor.Yellow:
                    return "#565105";

                case CardColor.White:
                    return "#231c1cc9";

                default:
                    return "white";
            }
        }
    }
}
namespace Logichroma.Areas.Game.Models.GameObjectModels
{
    public class CardModel
    {
        public int GameId { get; set; }
        public int GamePlayerId { get; set; }
        public int Order { get; set; }
        public int CardTypeId { get; set; }
        public int CardTypeFaceValue { get; set; }
        public int ColorId { get; set; }

        private string _colorName;
        public string ColorName
        {
            get => _colorName;
            set
            {
                _colorName = value;

                switch (_colorName)
                {
                    case "Blue":
                        BackgroundColor = "#3961f5";
                        TextColor = "white";
                        break;

                    case "Red":
                        BackgroundColor = "#900f0f";
                        TextColor = "#f1c7c7";
                        break;

                    case "Green":
                        BackgroundColor = "#008000";
                        TextColor = "#b4dcb8";
                        break;

                    case "Yellow":
                        BackgroundColor = "yellow";
                        TextColor = "#565105";
                        break;

                    case "White":
                        BackgroundColor = "#fbf4f2";
                        TextColor = "#231c1cc9";
                        break;
                }
            }
        }

        public string BackgroundColor { get; set; }
        public string TextColor { get; set; }
    }
}
using Logichroma.Areas.Game.Models.GameModels.ChildObjects;

namespace Logichroma.Areas.Game.Models.GameModels
{
    public class CardModel
    {
        public int GameId { get; set; }

        public int Order { get; set; }
        
        public int GamePlayerId { get; set; }
        
        public CardStateModel CardState { get; set; }

        public CardTypeModel CardType { get; set; }
        
        public ColorModel Color { get; set; }
    }
}
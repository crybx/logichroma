using Logichroma.Areas.Game.Models.GameModels.ChildObjects;

namespace Logichroma.Areas.Game.Models.GameModels
{
    public class CardModel
    {
        public int GameId { get; set; }

        public int Order { get; set; }
        
        public int GamePlayerId { get; set; }
        
        public string CardState { get; set; }

        public CardValueModel CardValue { get; set; }
        
        public CardSuitModel CardSuit { get; set; }

        public bool IsSuitRevealed { get; set; }

        public bool IsValueRevealed { get; set; }
    }
}
using AutoMapper;
using Logichroma.Areas.Game.Models.GameModels;
using Logichroma.Areas.Game.Models.GameModels.ChildObjects;
using Logichroma.Database;

namespace Logichroma
{
    public static class AutoMapperConfig
    {
        public static void InitializeMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Game, GameModel>();
                cfg.CreateMap<GameModel, Game>();

                cfg.CreateMap<GameCard, CardModel>();
                cfg.CreateMap<CardModel, GameCard>();

                cfg.CreateMap<GamePlayer, PlayerModel>();
                cfg.CreateMap<PlayerModel, GamePlayer>();

                cfg.CreateMap<CardState, CardStateModel>();
                cfg.CreateMap<CardStateModel, CardState>();

                cfg.CreateMap<CardType, CardTypeModel>();
                cfg.CreateMap<CardTypeModel, CardType>();

                cfg.CreateMap<Color, ColorModel>();
                cfg.CreateMap<ColorModel, Color>();

                cfg.CreateMap<GameStatus, GameStatusModel>();
                cfg.CreateMap<GameStatusModel, GameStatus>();

                cfg.CreateMap<GameStatusType, GameStatusTypeModel>();
                cfg.CreateMap<GameStatusTypeModel, GameStatusType>();
            });
        }
    }
}
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

                cfg.CreateMap<CardValue, CardValueModel>();
                cfg.CreateMap<CardValueModel, CardValue>();

                cfg.CreateMap<CardSuit, CardSuitModel>();
                cfg.CreateMap<CardSuitModel, CardSuit>();

                cfg.CreateMap<GameStatus, GameStatusModel>();
                cfg.CreateMap<GameStatusModel, GameStatus>();

                cfg.CreateMap<GameStatusType, GameStatusTypeModel>();
                cfg.CreateMap<GameStatusTypeModel, GameStatusType>();
            });
        }
    }
}
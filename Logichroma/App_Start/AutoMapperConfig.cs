using AutoMapper;
using Logichroma.Models.GameObjectModels;
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
                cfg.CreateMap<GameCard, CardModel>();
                cfg.CreateMap<GamePlayer, PlayerModel>();
                cfg.CreateMap<GameStatus, GameStatusModel>();
            });
        }
    }
}
using AutoMapper;
using Logichroma.Models.BusinessObjects;
using Logichroma.Models.Database;

namespace Logichroma
{
    public static class AutoMapperConfig
    {
        public static void InitializeMappings()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Game, GameModel>());
        }
    }
}
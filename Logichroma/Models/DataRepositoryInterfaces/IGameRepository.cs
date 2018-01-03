
using System.Collections.Generic;
using Logichroma.Models.BusinessObjects;

namespace Logichroma.Models.DataRepositoryInterfaces
{
    public interface IGameRepository
    {
        List<GameModel> GetGames();
        bool IsGameNameAvailable(string name);
        int AddGame(GameOptionsModel gameOptions);
    }
}


using System.Collections.Generic;
using Logichroma.Models.BusinessObjects;

namespace Logichroma.Models.DataRepositoryInterfaces
{
    public interface IGameRepository
    {
        List<GameModel> GetGames();
        bool IsGameNameAvailable(string name);
        GameModel AddGame(GameOptionsModel gameOptions);
        void AddPlayerToGame(string userId, GameModel game);
        void AddGameStatus(string gameStatus, GameModel game);
    }
}

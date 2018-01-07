
using System.Collections.Generic;
using Logichroma.Models.BusinessObjects;

namespace Logichroma.Models.DataRepositoryInterfaces
{
    public interface IGameRepository
    {
        GameModel GetGame(int gameId);
        List<GameModel> GetGames();
        bool IsGameNameAvailable(string name);
        GameModel AddGame(GameModel gameOptions);
        void AddPlayerToGame(string userId, int gameId);
        void AddGameStatus(string gameStatus, GameModel game);
    }
}

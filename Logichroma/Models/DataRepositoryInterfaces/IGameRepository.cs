using Logichroma.Models.BusinessObjects;
using System.Collections.Generic;

namespace Logichroma.Models.DataRepositoryInterfaces
{
    public interface IGameRepository
    {
        GameModel GetGame(int gameId);
        List<GameModel> GetGames();
        bool IsGameNameAvailable(string name);
        GameModel AddGame(GameModel gameOptions);
        void AddPlayerToGame(int gameId, string userId, string nickname);
        void AddGameStatus(string gameStatus, GameModel game);
    }
}

using Logichroma.Models.GameObjectModels;
using System.Collections.Generic;

namespace Logichroma.Models.DataRepositoryInterfaces
{
    public interface IGameRepository
    {
        GameModel GetGame(int gameId);
        List<GameModel> GetActiveGames();
        bool IsGameNameAvailable(string name);
        GameModel AddGame(GameModel gameOptions);
        void AddPlayerToGame(int gameId, string userId, string nickname, bool isOwner);
        void AddGameStatus(string gameStatus, int gameId);
    }
}

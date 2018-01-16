﻿using System.Collections.Generic;
using Logichroma.Areas.Game.Models.GameObjectModels;

namespace Logichroma.Areas.Game.Models.DataRepositoryInterfaces
{
    public interface IGameRepository
    {
        GameModel GetGame(int gameId);
        List<GameModel> GetActiveGames();
        bool IsGameNameAvailable(string name);
        GameModel AddGame(GameModel gameOptions);
        void AddPlayerToGame(int gameId, string userId, string nickname, bool isOwner);
        void AddGameStatus(string gameStatus, int gameId);
        void SetPlayerOrder(int gameId);
        void DealStartingCards(int gameId);
    }
}

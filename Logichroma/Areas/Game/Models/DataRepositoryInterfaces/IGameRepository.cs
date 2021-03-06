﻿using Logichroma.Areas.Game.Models.GameModels;
using Logichroma.GameEngine.Enums;
using System.Collections.Generic;

namespace Logichroma.Areas.Game.Models.DataRepositoryInterfaces
{
    public interface IGameRepository
    {
        GameModel GetGame(int gameId);
        List<GameModel> GetActiveGames();
        bool IsGameNameAvailable(string name);
        GameModel AddGame(GameModel gameOptions);
        void AddPlayerToGame(int gameId, string userId, string nickname, bool isOwner);
        void AddGameStatus(GameStatus gameStatus, int gameId);
        void SetPlayerOrder(int gameId);
        void DealStartingCards(int gameId);
        void DiscardCard(int order, int gameId);
        List<CardModel> GetPlayerCards(int gameId, int playerId);
        void GivePlayerColorHint(int gameId, int playerId, int colorId);
        void GivePlayerNumberHint(int gameId, int playerId, int numberId);
        void PlayCard(int order, int gameId);
        int GetCurrentPlayerNumber(int gameId);
    }
}

﻿
namespace Logichroma.Models.DataRepositoryInterfaces
{
    public interface IGameRepository
    {
        bool IsGameNameAvailable(string name);
        int AddGame(GameOptionsModel gameOptions);
    }
}
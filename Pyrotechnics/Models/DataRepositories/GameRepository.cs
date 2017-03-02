using System;
using System.Linq;
using Pyrotechnics.Models.Database;
using Pyrotechnics.Models.DataRepositoryInterfaces;

namespace Pyrotechnics.Models.DataRepositories
{
    public class GameRepository : IGameRepository
    {
        private readonly PyrotechnicsDbEntities _db = new PyrotechnicsDbEntities();

        public bool IsGameNameAvailable(string name)
        {
            var nameAlreadyExists = _db.Games.Any(g => g.Name == name);
            return !nameAlreadyExists;
        }

        public int AddGame(GameOptionsModel gameOptions)
        {
            var game = new Game
            {
                Name = gameOptions.GameTitle,
                DifficultyLvl = 1,
                NextCard = 1,
                StartDateTime = DateTime.Now
            };

            _db.Games.Add(game);
            _db.SaveChanges();

            return game.Id;
        }

        public void CreateShuffledDeck()
        {
            
        }
    }
}
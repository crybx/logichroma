using System;
using System.Linq;
using ChromaMatch.Models.Database;
using ChromaMatch.Models.DataRepositoryInterfaces;

namespace ChromaMatch.Models.DataRepositories
{
    public class GameRepository : IGameRepository
    {
        private readonly ChromaMatchDbEntities _db = new ChromaMatchDbEntities();

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
using ChromaMatch.Models;
using ChromaMatch.Models.DataRepositories;
using ChromaMatch.Models.DataRepositoryInterfaces;
using System.Web.Mvc;

namespace ChromaMatch.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameRepository _gameRepo;

        public GameController(IGameRepository gameRepo)
        {
            _gameRepo = gameRepo;
        }

        public GameController() : this(new GameRepository()) {}

        public ActionResult Start()
        {
            var model = new GameOptionsModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Start(GameOptionsModel options)
        {
            var gameTitleAvaible = _gameRepo.IsGameNameAvailable(options.GameTitle);

            if (gameTitleAvaible)
            {
                options.GameId = _gameRepo.AddGame(options);
                return View("Index", options);
            }

            return View();
        }
    }
}
using System.Web.Mvc;
using Pyrotechnics.Models;
using Pyrotechnics.Models.DataRepositories;
using Pyrotechnics.Models.DataRepositoryInterfaces;

namespace Pyrotechnics.Controllers
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
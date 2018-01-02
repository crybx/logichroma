using Logichroma.Models;
using Logichroma.Models.DataRepositories;
using Logichroma.Models.DataRepositoryInterfaces;
using System.Web.Mvc;

namespace Logichroma.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameRepository _gameRepo;

        public GameController(IGameRepository gameRepo)
        {
            _gameRepo = gameRepo;
        }

        public GameController() : this(new GameRepository()) {}

        public ActionResult Create()
        {
            var model = new GameOptionsModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(GameOptionsModel options)
        {
            var gameTitleAvaible = _gameRepo.IsGameNameAvailable(options.GameTitle);

            if (gameTitleAvaible)
            {
                options.GameId = _gameRepo.AddGame(options);
                return View("Index", options);
            }

            return Create();
        }
    }
}
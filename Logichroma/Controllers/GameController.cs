using Logichroma.Models;
using Logichroma.Models.DataRepositories;
using Logichroma.Models.DataRepositoryInterfaces;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

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

        public ActionResult Index()
        {
            var model = _gameRepo.GetGames();
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new GameOptionsModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(GameOptionsModel options)
        {
            var gameTitleAvaible = _gameRepo.IsGameNameAvailable(options.GameTitle);

            if (!gameTitleAvaible)
            {
                //TODO: Include message to tell user game title isn't available.
                return Create();
            }

            var gameModel = _gameRepo.AddGame(options);
            var userId = User.Identity.GetUserId();
                
            _gameRepo.AddPlayerToGame(userId, gameModel);

            return View("Created", gameModel);

        }
    }
}
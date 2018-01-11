using Logichroma.Models;
using Logichroma.Models.BusinessObjects;
using Logichroma.Models.DataRepositories;
using Logichroma.Models.DataRepositoryInterfaces;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace Logichroma.Controllers
{
    [Authorize]
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
            var model = new GameModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(GameModel options)
        {
            var gameTitleAvaible = _gameRepo.IsGameNameAvailable(options.Name);

            if (!gameTitleAvaible)
            {
                //TODO: Show user message that title isn't available.
                return Create();
            }

            var gameModel = _gameRepo.AddGame(options);
            var userId = User.Identity.GetUserId();
            
            //TODO: Allow creator of game to choose a nickname too.
            _gameRepo.AddPlayerToGame(gameModel.Id, userId, null);
            _gameRepo.AddGameStatus("Created", gameModel);

            return View("Created", gameModel);
        }

        public ActionResult Details(int gameId)
        {
            var model = new GameDetailsViewModel
            {
                Game = _gameRepo.GetGame(gameId),
                CurrentUser = User.Identity.GetUserId()
            };
            
            return View(model);
        }

        [HttpPost]
        public ActionResult Join(GameDetailsViewModel model)
        {
            var gameId = model.Game.Id;
            var userId = User.Identity.GetUserId();
            var nickname = string.IsNullOrWhiteSpace(model.PlayerNickname) ? null : model.PlayerNickname;

            _gameRepo.AddPlayerToGame(gameId, userId, nickname);

            return RedirectToAction(nameof(Details), new { gameId });
        }
    }
}
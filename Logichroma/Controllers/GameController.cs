using Logichroma.Models;
using Logichroma.Models.GameObjectModels;
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
            var model = _gameRepo.GetActiveGames();
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new GameDetailsViewModel { Game = new GameModel() };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(GameDetailsViewModel model)
        {
            var gameTitleAvaible = _gameRepo.IsGameNameAvailable(model.Game.Name);

            if (!gameTitleAvaible)
            {
                //TODO: Show user message that title isn't available.
                return Create();
            }

            model.Game = _gameRepo.AddGame(model.Game);

            var gameId = model.Game.Id;
            _gameRepo.AddGameStatus("Created", gameId);
            
            addPlayerToGame(model, true);

            return RedirectToAction(nameof(Details), new { gameId });
        }
        
        public ActionResult Details(int gameId)
        {
            var model = getGameDetails(gameId);
            
            return View(model);
        }

        [HttpPost]
        public ActionResult Join(GameDetailsViewModel model)
        {
            addPlayerToGame(model, false);

            return RedirectToAction(nameof(Details), new { gameId = model.Game.Id });
        }

        [HttpGet]
        public ActionResult StartGame(int gameId)
        {
            var model = getGameDetails(gameId);

            if (!model.CanStartGame) return View(nameof(Details), model);

            _gameRepo.AddGameStatus("Started", gameId);

            return View(nameof(Details), model);
        }

        private void addPlayerToGame(GameDetailsViewModel model, bool isOwner)
        {
            var userId = User.Identity.GetUserId();
            var nickname = string.IsNullOrWhiteSpace(model.PlayerNickname) ? null : model.PlayerNickname;

            _gameRepo.AddPlayerToGame(model.Game.Id, userId, nickname, isOwner);
        }

        private GameDetailsViewModel getGameDetails(int gameId)
        {
            var model = new GameDetailsViewModel
            {
                Game = _gameRepo.GetGame(gameId),
                CurrentUserId = User.Identity.GetUserId()
            };

            return model;
        }
    }
}
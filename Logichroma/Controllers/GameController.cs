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

            _gameRepo.AddGameStatus("Created", model.Game);
            
            addPlayerToGame(model);

            return RedirectToAction(nameof(Details), new { gameId = model.Game.Id });
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
            addPlayerToGame(model);

            return RedirectToAction(nameof(Details), new { gameId = model.Game.Id });
        }

        private void addPlayerToGame(GameDetailsViewModel model)
        {
            var userId = User.Identity.GetUserId();
            var nickname = string.IsNullOrWhiteSpace(model.PlayerNickname) ? null : model.PlayerNickname;

            _gameRepo.AddPlayerToGame(model.Game.Id, userId, nickname);
        }
    }
}
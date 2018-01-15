using Logichroma.Areas.Game.Models;
using Logichroma.Areas.Game.Models.GameObjectModels;
using System.Web.Mvc;

namespace Logichroma.Areas.Game.Controllers
{
    [Authorize]
    public class CreateController : GameController
    {
        public ActionResult Index()
        {
            var model = new GameDetailsViewModel { Game = new GameModel() };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(GameDetailsViewModel model)
        {
            var gameTitleAvaible = GameRepo.IsGameNameAvailable(model.Game.Name);

            if (!gameTitleAvaible)
            {
                //TODO: Show user message that title isn't available.
                return RedirectToAction("Index");
            }

            model.Game = GameRepo.AddGame(model.Game);

            var gameId = model.Game.Id;
            GameRepo.AddGameStatus("Created", gameId);

            AddPlayerToGame(model, true);
            
            return RedirectToAction("Index", "Details", new { gameId });
        }
    }
}
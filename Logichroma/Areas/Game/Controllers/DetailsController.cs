using Logichroma.Areas.Game.Models;
using System.Web.Mvc;
using Logichroma.GameEngine.Enums;

namespace Logichroma.Areas.Game.Controllers
{
    [Authorize]
    public class DetailsController : GameController
    {
        public ActionResult Index(int gameId)
        {
            var model = GetGameDetails(gameId);
            return View(model);
        }

        [HttpPost]
        public ActionResult Join(GameDetailsViewModel model)
        {
            AddPlayerToGame(model, false);

            return RedirectToAction(nameof(Index), new { gameId = model.Game.Id });
        }

        [HttpGet]
        public ActionResult StartGame(int gameId)
        {
            var model = GetGameDetails(gameId);

            if (!model.CanStartGame) return View(nameof(Index), model);

            GameRepo.SetPlayerOrder(gameId);
            GameRepo.DealStartingCards(gameId);
            GameRepo.AddGameStatus(GameStatus.Started, gameId);

            return RedirectToAction("Index", "Play", new { gameId });
        }
    }
}
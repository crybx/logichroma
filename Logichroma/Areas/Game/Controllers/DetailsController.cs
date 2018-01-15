using Logichroma.Areas.Game.Models;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace Logichroma.Areas.Game.Controllers
{
    [Authorize]
    public class DetailsController : GameController
    {
        public ActionResult Index(int gameId)
        {
            var model = getGameDetails(gameId);
            
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
            var model = getGameDetails(gameId);

            if (!model.CanStartGame) return View(nameof(Index), model);

            GameRepo.AddGameStatus("Started", gameId);

            return View(nameof(Index), model);
        }
        
        private GameDetailsViewModel getGameDetails(int gameId)
        {
            var model = new GameDetailsViewModel
            {
                Game = GameRepo.GetGame(gameId),
                CurrentUserId = User.Identity.GetUserId()
            };

            return model;
        }
    }
}
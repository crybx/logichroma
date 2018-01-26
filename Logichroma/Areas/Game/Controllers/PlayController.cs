using System.Web.Mvc;

namespace Logichroma.Areas.Game.Controllers
{
    [Authorize]
    public class PlayController : GameController
    {
        public ActionResult Index(int gameId)
        {
            var model = GetGameDetails(gameId);
            return View(model);
        }

        public ActionResult Discard(int order, int gameId)
        {
            GameRepo.DiscardCard(order, gameId);
            return RedirectToAction(nameof(Index), new { gameId });
        }
    }
}
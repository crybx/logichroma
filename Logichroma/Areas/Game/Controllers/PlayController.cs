using Logichroma.Areas.Game.Models;
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

        public ActionResult GetHintOptions(int gameId, int playerId)
        {
            var model = new HintOptionsViewModel
            {
                GameId = gameId,
                PlayerId = playerId,
                Cards = GameRepo.GetPlayerCards(gameId, playerId)
            };

            return PartialView("_HintOptions", model);
        }

        public ActionResult GiveColorHint(HintOptionsViewModel model)
        {
            GameRepo.GivePlayerColorHint(model.GameId, model.PlayerId, model.SelectedColorId);

            return RedirectToAction(nameof(Index), new { model.GameId });
        }

        public ActionResult GiveNumberHint(HintOptionsViewModel model)
        {
            GameRepo.GivePlayerNumberHint(model.GameId, model.PlayerId, model.SelectedNumberId);

            return RedirectToAction(nameof(Index), new { model.GameId });
        }
    }
}
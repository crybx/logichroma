using System.Web.Mvc;

namespace Logichroma.Areas.Game.Controllers
{
    [Authorize]
    public class ListController : GameController
    {
        public ActionResult Index()
        {
            var model = GameRepo.GetActiveGames();
            return View(model);
        }
    }
}
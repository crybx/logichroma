using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    }
}
using System.Web.Mvc;

namespace Logichroma.Areas.Admin.Controllers
{
    [Authorize(Roles = "canEditGameAssets")]
    public class DashboardController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}

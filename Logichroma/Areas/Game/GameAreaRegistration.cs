using System.Web.Mvc;

namespace Logichroma.Areas.Game
{
    public class GameAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Game";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Game_default",
                "Game/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
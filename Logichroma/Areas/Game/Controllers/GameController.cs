using Logichroma.Areas.Game.Models;
using Logichroma.Areas.Game.Models.DataRepositories;
using Logichroma.Areas.Game.Models.DataRepositoryInterfaces;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace Logichroma.Areas.Game.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        protected readonly IGameRepository GameRepo;

        public GameController(IGameRepository gameRepo)
        {
            GameRepo = gameRepo;
        }

        public GameController() : this(new GameRepository()) { }

        public void AddPlayerToGame(GameDetailsViewModel model, bool isOwner)
        {
            var userId = User.Identity.GetUserId();
            var nickname = string.IsNullOrWhiteSpace(model.PlayerNickname) ? null : model.PlayerNickname;

            GameRepo.AddPlayerToGame(model.Game.Id, userId, nickname, isOwner);
        }

        public GameDetailsViewModel GetGameDetails(int gameId)
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
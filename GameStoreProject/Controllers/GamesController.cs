using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Protocols;
using GameStore.Services.Interfaces;

namespace GameStore.Web.Controllers
{
    public class GamesController : Controller
    {
        private ICommentsServices comments;
        private IGameServices games;
        private IGenreServices genres;
        private IPlatformServices platforms;

        public GamesController(IGameServices gameServices, IGenreServices genreServices, ICommentsServices commentsServices, IPlatformServices platformServices)
        {
            comments = commentsServices;
            games = gameServices;
            genres = genreServices;
            platforms = platformServices;
        }

        public JsonResult GetAllGames()
        {
            var result = games.GetGames().ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
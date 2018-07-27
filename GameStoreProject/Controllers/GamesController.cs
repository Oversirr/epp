using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Protocols;
using GameStore.Services.DTO;
using GameStore.Services.Interfaces;
using Newtonsoft.Json;

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
            var gamesList = games.GetGames().ToList();
            var result = SerializeContent(gamesList);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        

        public JsonResult GetGameDetails(string key)
        {
            var game = games.GetGameByKey(key);
            var result = SerializeContent(game);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        private static string SerializeContent(Object o)
        {
            var result = JsonConvert.SerializeObject(o, Formatting.None,
                new JsonSerializerSettings
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects
                });
            return result;
        }
    }
}
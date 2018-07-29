using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;
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

        [HttpGet]
        public JsonResult GetAllGames()
        {
            var gamesList = games.GetGames().ToList();
            //var result = SerializeContent(gamesList);
            return Json(gamesList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetGameDetails(string key)
        {
            var game = games.GetGameByKey(key);
            //var result = SerializeContent(game);
            return Json(game, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CreateGame(string game)
        {
            var serializer = new JavaScriptSerializer();
            var gameToCreate = serializer.Deserialize<GameCreateDTO>(game);
            games.CreateNewGame(gameToCreate);
            return Json(new {success = true, responseText = "Game succesfuly created!"},
                JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EditGame(string game)
        {
            var serializer = new JavaScriptSerializer();
            var gameToEdit = serializer.Deserialize<GameEditDTO>(game);
            games.EditGame(gameToEdit);
            return Json(new {success = true, responseText = "Game succesfuly edited"},
                JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteGame(string game)
        {
            var serializer = new JavaScriptSerializer();
            var gameToDelete = serializer.Deserialize<GameEditDTO>(game);
            games.DeleteGame(gameToDelete);
            return Json(new {success = true, responseText = "Game succesfuly deleted"},
                JsonRequestBehavior.AllowGet);
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
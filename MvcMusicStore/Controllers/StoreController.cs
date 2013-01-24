using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers {
    public class StoreController : Controller {
        MusicStoreEntities storeDB = new MusicStoreEntities();
        //
        // GET: /Store/

        public ActionResult Details() 
        {
            return View();
        }

        public ActionResult Browse() {
            return View();
        }

        public ActionResult Index() 
        {
            var genres = storeDB.Genres;
            return View(genres);
        }


        //
        // GET: /Store/GenreMenu

        [ChildActionOnly]
        public ActionResult GenreMenu()
        {
            var genres = storeDB.Genres.Take(9).ToList();

            return PartialView(genres);
        }

    }
}

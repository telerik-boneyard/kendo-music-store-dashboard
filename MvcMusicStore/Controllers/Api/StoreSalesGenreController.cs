using System;
using System.Linq;
using System.Web.Http;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers.Api
{
    public class StoreSalesGenreController : ApiController
    {
        readonly MusicStoreEntities storeDB = new MusicStoreEntities();

        // GET api/storesalesrevenue
        public IQueryable<SalesByGenre> Get(string start, string end)
        {
            var random = new Random();
            return storeDB.Genres.Select(x => x.Name).ToList().Select(x => new SalesByGenre { Genre = x, Count = random.Next(5,30) }).AsQueryable();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            storeDB.Dispose();
        }
    }
}

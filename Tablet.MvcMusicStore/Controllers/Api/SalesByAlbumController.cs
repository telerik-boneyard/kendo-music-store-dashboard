using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Tablet.MvcMusicStore.Models;

namespace Tablet.MvcMusicStore.Controllers.Api
{
    /// <summary>
    /// Retrieves sales information by album
    /// </summary>
    public class SalesByAlbumController : ApiController
    {
        private readonly IDashboardEntities _entities;

        /// <summary>
        /// Initializes a new instance of <see cref="SalesByAlbumController"/>
        /// </summary>
        /// <param name="entities">An <see cref="IDashboardEntities"/> dependency</param>
        public SalesByAlbumController(IDashboardEntities entities)
        {
            _entities = entities;
        }

        /// <summary>
        /// Retrieves sales info by album and and year
        /// </summary>
        /// <param name="albumId">An <see cref="int"/> indicating the albumId</param>
        /// <param name="year">An <see cref="int"/> indicating the year</param>
        /// <returns>An <see cref="IEnumerable{dynamic}"/> containing the sales information</returns>
        [HttpGet]
        public IEnumerable<dynamic> Get(int albumId, int year)
        {
            var random = new Random();
            var album = _entities.Albums.SingleOrDefault(a => a.AlbumId == albumId);

            if (null == album)
                throw new HttpException(404, "Album not found");

            var start = new DateTime(year, 1, 1);
            var end = new DateTime(year + 1, 1, 1);

            for (var date = start; date < end; date = date.AddDays(1))
            {
                yield return new
                {
                    Date = date,
                    Sales = (random.Next(1, date.Month * 2) + 4) * 10000
                };
            }
        }
    }
}

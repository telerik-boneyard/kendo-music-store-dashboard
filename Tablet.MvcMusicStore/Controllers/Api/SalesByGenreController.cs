using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Tablet.MvcMusicStore.Models;

namespace Tablet.MvcMusicStore.Controllers.Api
{
    /// <summary>
    /// Retrieves store's sales information
    /// </summary>
    public class SalesByGenreController : ApiController
    {
        private readonly IDashboardEntities _entities;
        private readonly Random _random = new Random();

        public SalesByGenreController(IDashboardEntities entities)
        {
            _entities = entities;
        }

        /// <summary>
        /// Retrieves sales information for the last week
        /// </summary>
        /// <remarks>GET api/salesbygenre/weekly</remarks>
        /// <returns>An <see cref="IEnumerable{dynamic}"/> containing the week's sales.</returns>
        [HttpGet]
        public IEnumerable<dynamic> Weekly()
        {
            var end = DateTime.Today;
            var start = end.AddDays(-7);
            var genres = _entities.Genres.Take(3).ToList();

            for (var date = start; date <= end; date = date.AddDays(1))
            {
                foreach (var genre in genres)
                {
                    yield return new
                    {
                        Date = date,
                        Genre = genre.Name,
                        Sales = _random.Next(5000,10000)
                    };    
                }
            }
        }

        /// <summary>
        /// Retrieves sales information for the last month
        /// </summary>
        /// <remarks>GET api/salesbygenre/monthly</remarks>
        /// <returns>An <see cref="IEnumerable{dynamic}"/> containing the month's sales.</returns>
        [HttpGet]
        public IEnumerable<dynamic> Monthly()
        {
            var end = DateTime.Today;
            var start = end.AddMonths(-1);
            var genres = _entities.Genres.Take(3).ToList();

            for (var date = start; date <= end; date = date.AddDays(1))
            {
                foreach (var genre in genres)
                {
                    yield return new
                    {
                        Date = date,
                        Genre = genre.Name,
                        Sales = _random.Next(5000, 10000)
                    };
                }
            }
        }

        /// <summary>
        /// Retrieves sales information for the last year
        /// </summary>
        /// <remarks>GET api/salesbygenre/yearly</remarks>
        /// <returns>An <see cref="IEnumerable{dynamic}"/> containing the year's sales.</returns>
        [HttpGet]
        public IEnumerable<dynamic> Yearly()
        {
            var end = DateTime.Today;
            var start = end.AddYears(-1);
            var genres = _entities.Genres.Take(3).ToList();

            for (var date = start; date <= end; date = date.AddMonths(1))
            {
                foreach (var genre in genres)
                {
                    yield return new
                    {
                        Date = date,
                        Genre = genre.Name,
                        Sales = _random.Next(50000, 100000)
                    };
                }
            }
        }
    }
}

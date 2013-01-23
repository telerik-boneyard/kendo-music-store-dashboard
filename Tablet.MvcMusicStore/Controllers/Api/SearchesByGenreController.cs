using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Tablet.MvcMusicStore.Models;

namespace Tablet.MvcMusicStore.Controllers.Api
{
    /// <summary>
    /// Retrieves store-search related info
    /// </summary>
    public class SearchesByGenreController : ApiController
    {
        private readonly IDashboardEntities _entities;
        private readonly Random _random = new Random();

        /// <summary>
        /// Initializes a new instance of <see cref="SearchesByGenreController"/>
        /// </summary>
        /// <param name="entities">An <see cref="IDashboardEntities"/> dependency</param>
        public SearchesByGenreController(IDashboardEntities entities)
        {
            _entities = entities;
        }

        /// <summary>
        /// Gets weekly search stats
        /// </summary>
        /// <remarks>GET api/salesbygenre/weekly</remarks>
        /// <returns>An <see cref="IEnumerable{dynamic}"/> containing the weekly stats.</returns>
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
                        Searches = _random.Next(50000,100000)
                    };    
                }
            }
        }

        /// <summary>
        /// Gets monthly search stats
        /// </summary>
        /// <remarks>GET api/salesbygenre/monthly</remarks>
        /// <returns>An <see cref="IEnumerable{dynamic}"/> containing the monthly stats.</returns>
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
                        Searches = _random.Next(50000, 100000)
                    };
                }
            }
        }

        /// <summary>
        /// Gets yearly search stats
        /// </summary>
        /// <remarks>GET api/salesbygenre/yearly</remarks>
        /// <returns>An <see cref="IEnumerable{dynamic}"/> containing the yearly stats.</returns>
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
                        Searches = _random.Next(500000, 1000000)
                    };
                }
            }
        }
    }
}

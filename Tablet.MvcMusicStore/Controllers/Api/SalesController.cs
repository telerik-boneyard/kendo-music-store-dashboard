using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Tablet.MvcMusicStore.Controllers.Api
{
    /// <summary>
    /// Retrieves stores general sales stats
    /// </summary>
    public class SalesController : ApiController
    {
        /// <summary>
        /// Summarizes the total information to be displayed in the dashboard landing page
        /// </summary>
        /// <remarks>GET /Sales/Totals</remarks>
        /// <returns>A dynamic structure containing the summarized sale amounts.</returns>
        [HttpGet]
        public dynamic Totals()
        {
            var random = new Random();
            return new
            {
                Today = random.Next(500, 1000),
                Week = random.Next(5000, 10000),
                Month = random.Next(50000, 100000),
                LastMonth = random.Next(50000, 100000)
            };
        }

        /// <summary>
        /// Retrieves the total sales for the specified period
        /// </summary>
        /// <remarks>GET /Sales/TotalSales</remarks>
        /// <param name="period">An <see cref="int"/> indicating the period in days</param>
        /// <returns>An <see cref="IEnumerable{dynamic}"/> containing the total sales</returns>
        [HttpGet]
        public IEnumerable<dynamic> TotalSales(int period)
        {
            var random = new Random();

            var end = DateTime.Now;
            var start = end.Subtract(new TimeSpan(period, 0, 0, 0));

            for (var date = start; date < end; date = date.AddDays(1))
            {
                yield return new
                {
                    Date = date,
                    Sales = (random.Next(1, date.Millisecond * 2) + 4)
                };
            }

        }

        /// <summary>
        /// Retrieves total album sales for the specified period
        /// </summary>
        /// <param name="period">An <see cref="int"/> indicating the period in days</param>
        /// <returns>An <see cref="IEnumerable{dynamic}"/> containing the album sales</returns>
        [HttpGet]
        public IEnumerable<dynamic> AlbumSales(int period)
        {
            var random = new Random();

            var end = DateTime.Now;
            var start = end.Subtract(new TimeSpan(period, 0, 0, 0));

            for (var date = start; date < end; date = date.AddDays(1))
            {
                yield return new
                {
                    Date = date,
                    Sales = (random.Next(1, date.Millisecond * 2) + 4)
                };
            }

        }

        /// <summary>
        /// Retrieves total track (single) sales for the specified period
        /// </summary>
        /// <param name="period">An <see cref="int"/> indicating the period in days</param>
        /// <returns>An <see cref="IEnumerable{dynamic}"/> containing the track (single) sales</returns>
        [HttpGet]
        public IEnumerable<dynamic> SingleSales(int period)
        {
            var random = new Random();

            var end = DateTime.Now;
            var start = end.Subtract(new TimeSpan(period, 0, 0, 0));

            for (var date = start; date < end; date = date.AddDays(1))
            {
                yield return new
                {
                    Date = date,
                    Sales = (random.Next(1, date.Millisecond * 2) + 4)
                };
            }

        }

        /// <summary>
        /// Retrieves the total downloads for the specified period.
        /// </summary>
        /// <param name="period">An <see cref="int"/> indicating the period in days</param>
        /// <returns>An <see cref="IEnumerable{dynamic}"/> containing total downloads</returns>
        [HttpGet]
        public IEnumerable<dynamic> TotalDownloads(int period)
        {
            var random = new Random();

            var end = DateTime.Now;
            var start = end.Subtract(new TimeSpan(period, 0, 0, 0));

            for (var date = start; date < end; date = date.AddDays(1))
            {
                yield return new
                {
                    Date = date,
                    Sales = (random.Next(1, date.Millisecond * 2) + 4)
                };
            }

        }

        /// <summary>
        /// Retrieves the total ticket sales for the specified period.
        /// </summary>
        /// <param name="period">An <see cref="int"/> indicating the period in days</param>
        /// <returns>An <see cref="IEnumerable{dynamic}"/> containing total ticket sales</returns>
        [HttpGet]
        public IEnumerable<dynamic> TicketSales(int period)
        {
            var random = new Random();

            var end = DateTime.Now;
            var start = end.Subtract(new TimeSpan(period, 0, 0, 0));

            for (var date = start; date < end; date = date.AddDays(1))
            {
                yield return new
                {
                    Date = date,
                    Sales = (random.Next(1, date.Millisecond * 2) + 4)
                };
            }

        }
    }
}

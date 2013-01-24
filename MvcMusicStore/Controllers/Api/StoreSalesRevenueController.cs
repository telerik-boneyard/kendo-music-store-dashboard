using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers.Api
{
    public class StoreSalesRevenueController : ApiController
    {
        readonly MusicStoreEntities storeDB = new MusicStoreEntities();

        // GET api/storesalesrevenue
        public IQueryable<SalesRevenue> Get(string start, string end)
        {
            storeDB.Configuration.ProxyCreationEnabled = false;
            var startDate = DateTime.Parse(start);
            var endDate = DateTime.Parse(end);
            return GetFakeData(startDate, endDate);
        }

        //private IQueryable<SalesRevenue> GetRealData(DateTime start, DateTime end)
        //{
        //    var data = (from o in storeDB.Orders
        //               where o.OrderDate >= start && o.OrderDate <= end
        //               group o by new { o.OrderDate.Year, o.OrderDate.Month, o.OrderDate.Day } into og
        //               select new
        //               {
        //                   Day = og.Key,
        //                   Orders = og.Count(),
        //                   Revenue = og.Sum(x => x.Total)
        //               }).ToArray();

        //    return data.Select(x => new SalesRevenue
        //    {
        //        Day = new DateTime(x.Day.Year, x.Day.Month, x.Day.Day),
        //        Orders = x.Orders,
        //        Revenue = x.Revenue
        //    }).AsQueryable();
        //}

        private IQueryable<SalesRevenue> GetFakeData(DateTime start, DateTime end)
        {
            var days = GetFakeDays(start, end);
            return days;
            return days.GroupBy(x => new { Year = x.Day.Year, Week = Math.Floor(x.Day.DayOfYear / 7d) })
                .Select(x => new SalesRevenue
                {
                    Day = x.First().Day,
                    Display = "?",
                    Orders = x.Sum(y => y.Orders),
                    Revenue = x.Sum(y => y.Revenue)
                });
        }

        private IQueryable<SalesRevenue> GetFakeDays(DateTime start, DateTime end)
        {
            var random = new Random();
            var numOfDays = (int)(end - start).TotalDays;
            var data = new List<SalesRevenue>(numOfDays);
            for (var i = 0; i < numOfDays; i++)
            {
                data.Add(new SalesRevenue
                {
                    Day = (start + TimeSpan.FromDays(i)).Date,
                    Display = (start + TimeSpan.FromDays(i)).Date.ToString("MMM dd"),
                    Orders = random.Next(60, 90),
                    Revenue = random.Next(8, 10) * random.Next(60,90)
                });
            }
            return data.AsQueryable();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            storeDB.Dispose();
        }
    }
}

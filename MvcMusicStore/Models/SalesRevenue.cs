using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMusicStore.Models
{
    public class SalesRevenue
    {
        public DateTime Day { get; set; }
        public int Orders { get; set; }
        public decimal Revenue { get; set; }
        public string Display { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Tablet.MvcMusicStore.Models
{
    public class DashboardEntities : DbContext, IDashboardEntities
    {
        public IDbSet<Album> Albums { get; set; }
        public IDbSet<Genre> Genres { get; set; }
        public IDbSet<Artist> Artists { get; set; }

        public IDbSet<Track> Tracks { get; set; }

        public IDbSet<Order> Orders { get; set; }
        public IDbSet<OrderDetail> OrderDetails { get; set; }
    }

    public interface IDashboardEntities
    {
        IDbSet<Album> Albums { get; set; }
        IDbSet<Genre> Genres { get; set; }
        IDbSet<Artist> Artists { get; set; }

        int SaveChanges();
    }
}
namespace Tablet.MvcMusicStore.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal class Configuration : DbMigrationsConfiguration<Tablet.MvcMusicStore.Models.DashboardEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Tablet.MvcMusicStore.Models.DashboardEntities context)
        {
            var sample = new SampleData();
            sample.Seed(context);
        }
    }
}

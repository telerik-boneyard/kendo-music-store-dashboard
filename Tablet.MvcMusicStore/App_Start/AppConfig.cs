using System.Data.Entity;
using Tablet.MvcMusicStore.Migrations;
using Tablet.MvcMusicStore.Models;

namespace Tablet.MvcMusicStore
{
    /// <summary>
    /// Configures the application.
    /// </summary>
    public static class AppConfig
    {
        public static void Config()
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<DashboardEntities, Configuration>());
            Database.SetInitializer<DashboardEntities>(null);

            using (var context = new DashboardEntities())
            {
                context.Database.Initialize(true);
            }
        }
    }
}
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
            #if DEBUG
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<DashboardEntities, Configuration>());
            #else
                Database.SetInitializer<DashboardEntities>(null);
            #endif
            using (var context = new DashboardEntities())
            {
                context.Database.Initialize(true);
            }
        }
    }
}
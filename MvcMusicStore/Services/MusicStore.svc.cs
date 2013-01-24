using System.Configuration;
using System.Data.Services;
using System.Data.Services.Common;
using System.Web;
using MvcMusicStore.Models;

namespace MvcMusicStore.Services
{
    public class MusicStore : DataService<MusicStoreEntities>
    {
        public static void InitializeService(DataServiceConfiguration config)
        {
            config.SetEntitySetAccessRule("Albums", EntitySetRights.All);
            config.SetEntitySetAccessRule("Artists", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("Genres", EntitySetRights.AllRead);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;
        }

        [ChangeInterceptor("Albums")]
        public void AlbumChangeInterceptor(Album album, UpdateOperations operations)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated || !HttpContext.Current.User.IsInRole("Administrator"))
                throw new DataServiceException(401, "Unauthorized");
            if (ConfigurationManager.AppSettings["enableEdits"] != "true")
                throw new DataServiceException(200, "Success");
        }
    }
}

using System.Web.Http;

namespace Tablet.MvcMusicStore
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //this allows webapi controllers to return dynamic types...
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //    );

            config.Routes.MapHttpRoute(
                name: "Sales",
                routeTemplate: "api/Sales/{action}/{period}",
                defaults: new { controller = "Sales", period = 30}
                );

            config.Routes.MapHttpRoute(
               name: "Social",
               routeTemplate: "api/Social/{action}",
               defaults: new { controller = "Social" }
               );

            config.Routes.MapHttpRoute(
                name: "Top",
                routeTemplate: "api/Top/{action}/",
                defaults: new { controller = "Top"}
                );

            config.Routes.MapHttpRoute(
                name: "SalesByGenreApi",
                routeTemplate: "api/SalesByGenre/{action}",
                defaults: new { controller = "SalesByGenre"}
                );

            config.Routes.MapHttpRoute(
               name: "SearchesByGenreApi",
               routeTemplate: "api/SearchesByGenre/{action}",
               defaults: new { controller = "SearchesByGenre" }
               );

            config.Routes.MapHttpRoute(
                name: "SalesByAlbumApi",
                routeTemplate: "api/SalesByAlbum/{albumId}/{year}",
                defaults: new { controller = "SalesByAlbum" }
                );
        }
    }
}
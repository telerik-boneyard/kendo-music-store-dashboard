using System.Web.Http;
using Microsoft.Practices.Unity;
using Tablet.MvcMusicStore.Models;

namespace Tablet.MvcMusicStore
{
    public static class UnityConfig
    {
        public static void Initialize()
        {
            var container = BuildUnityContainer();
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            //Use unity IoC Container to resolve the EntityFramework dbContext...
            container.RegisterType<IDashboardEntities, DashboardEntities>(new HierarchicalLifetimeManager());

            return container;
        }
    }
}
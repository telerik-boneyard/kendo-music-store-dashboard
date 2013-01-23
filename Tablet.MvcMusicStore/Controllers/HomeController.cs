using System.Web.Mvc;

namespace Tablet.MvcMusicStore.Controllers
{
    /// <summary>
    /// Home controller
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Renders the index view
        /// </summary>
        /// <returns>An <see cref="ActionResult"/> containing the index view.</returns>
        public ActionResult Index()
        {
            return View();
        }

    }
}

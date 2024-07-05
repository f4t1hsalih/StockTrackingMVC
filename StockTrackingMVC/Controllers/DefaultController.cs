using System.Web.Mvc;

namespace StockTrackingMVC.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}
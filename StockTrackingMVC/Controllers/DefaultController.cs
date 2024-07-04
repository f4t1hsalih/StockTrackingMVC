using System.Web.Mvc;

namespace StockTrackingMVC.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
    }
}
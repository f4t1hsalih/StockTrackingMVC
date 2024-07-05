using System.Web.Mvc;

namespace StockTrackingMVC.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Unauthorized()
        {
            return View();
        }
    }
}

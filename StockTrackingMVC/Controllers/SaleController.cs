using StockTrackingMVC.Models.Entity;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace StockTrackingMVC.Controllers
{
    public class SaleController : Controller
    {
        // GET: Sale
        public ActionResult Index()
        {
            using (DB_StockTrackingMVCEntities db = new DB_StockTrackingMVCEntities())
            {
                var sales = db.tbl_sales
              .Include(s => s.tbl_products)
              .Include(s => s.tbl_staff)
              .Include(s => s.tbl_customers)
              .ToList();
                return View(sales);
            }
        }
    }
}
using StockTrackingMVC.Models.Entity;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace StockTrackingMVC.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index(int sayfa = 1)
        {
            using (DB_StockTrackingMVCEntities db = new DB_StockTrackingMVCEntities())
            {
                //var customers = db.tbl_customers.ToList();
                var customerList = db.tbl_customers.ToList().ToPagedList(sayfa, 10);
                return View(customerList);
            }
        }
    }
}
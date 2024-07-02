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
        public ActionResult Index(int page = 1)
        {
            using (DB_StockTrackingMVCEntities db = new DB_StockTrackingMVCEntities())
            {
                //var customers = db.tbl_customers.ToList();
                var customerList = db.tbl_customers.ToList().ToPagedList(page, 10);
                return View(customerList);
            }
        }

        // AddCustomer
        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCustomer(tbl_customers customers)
        {
            using (DB_StockTrackingMVCEntities db = new DB_StockTrackingMVCEntities())
            {
                db.tbl_customers.Add(customers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}
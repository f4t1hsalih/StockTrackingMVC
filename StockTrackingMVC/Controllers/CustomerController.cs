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
                var customerList = db.tbl_customers.Where(x => x.ctm_status != false).ToList().ToPagedList(page, 10);
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
                customers.ctm_status = true;
                db.tbl_customers.Add(customers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        // DeleteCustomer
        public ActionResult DeleteCustomer(int id)
        {
            using (DB_StockTrackingMVCEntities db = new DB_StockTrackingMVCEntities())
            {
                var value = db.tbl_customers.Find(id);
                value.ctm_status = false;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        // UpdateCustomer
        [HttpGet]
        public ActionResult UpdateCustomer(int id)
        {
            using (DB_StockTrackingMVCEntities db = new DB_StockTrackingMVCEntities())
            {
                var values = db.tbl_customers.Find(id);
                return View(values);
            }
        }
        [HttpPost]
        public ActionResult UpdateCustomer(tbl_customers customers)
        {
            using (DB_StockTrackingMVCEntities db = new DB_StockTrackingMVCEntities())
            {
                var value = db.tbl_customers.Find(customers.ctm_id);
                value.ctm_name = customers.ctm_name;
                value.ctm_surname = customers.ctm_surname;
                value.ctm_city = customers.ctm_city;
                value.ctm_balance = customers.ctm_balance;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}
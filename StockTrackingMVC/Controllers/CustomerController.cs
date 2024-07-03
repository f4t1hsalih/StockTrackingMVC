using PagedList;
using StockTrackingMVC.Models.Entity;
using System.Linq;
using System.Web.Mvc;

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
            if (!ModelState.IsValid)
            {
                return View(customers);
            }

            // Varsayılan değerler ayarlama
            if (customers.ctm_balance == null)
            {
                customers.ctm_balance = 0;
            }
            customers.ctm_status = true;

            // Veritabanı işlemleri
            using (DB_StockTrackingMVCEntities db = new DB_StockTrackingMVCEntities())
            {
                db.tbl_customers.Add(customers);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // DeleteCustomer
        public ActionResult DeleteCustomer(int id)
        {
            using (DB_StockTrackingMVCEntities db = new DB_StockTrackingMVCEntities())
            {
                var customer = db.tbl_customers.Find(id);
                if (customer == null)
                {
                    return HttpNotFound();
                }

                customer.ctm_status = false;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        // UpdateCustomer
        [HttpGet]
        public ActionResult UpdateCustomer(int id)
        {
            using (DB_StockTrackingMVCEntities db = new DB_StockTrackingMVCEntities())
            {
                var customer = db.tbl_customers.Find(id);
                if (customer == null)
                {
                    return HttpNotFound();
                }
                return View(customer);
            }
        }

        [HttpPost]
        public ActionResult UpdateCustomer(tbl_customers customers)
        {
            if (!ModelState.IsValid)
            {
                return View(customers);
            }

            // Varsayılan değerler ayarlama
            if (customers.ctm_balance == null)
            {
                customers.ctm_balance = 0;
            }

            using (DB_StockTrackingMVCEntities db = new DB_StockTrackingMVCEntities())
            {
                var customerToUpdate = db.tbl_customers.Find(customers.ctm_id);
                if (customerToUpdate == null)
                {
                    return HttpNotFound();
                }

                customerToUpdate.ctm_name = customers.ctm_name;
                customerToUpdate.ctm_surname = customers.ctm_surname;
                customerToUpdate.ctm_city = customers.ctm_city;
                customerToUpdate.ctm_balance = customers.ctm_balance;

                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}
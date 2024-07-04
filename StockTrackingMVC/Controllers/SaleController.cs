using StockTrackingMVC.Models.Entity;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace StockTrackingMVC.Controllers
{
    public class SaleController : Controller
    {
        private DB_StockTrackingMVCEntities db = new DB_StockTrackingMVCEntities();

        // GET: Sale
        public ActionResult Index()
        {
            var sales = db.tbl_sales
                .Include(s => s.tbl_products)
                .Include(s => s.tbl_staff)
                .Include(s => s.tbl_customers)
                .ToList();

            return View(sales);
        }

        // Add Sale
        [HttpGet]
        public ActionResult AddSale()
        {
            ViewBag.ProductForSales = new SelectList(db.tbl_products, "prd_id", "prd_name");
            ViewBag.StaffForSales = new SelectList(db.tbl_staff.ToList().Select(s => new
            {
                stf_id = s.stf_id,
                stf_name = s.stf_name + " " + s.stf_surname
            }), "stf_id", "stf_name");
            ViewBag.CustomerForSales = new SelectList(db.tbl_customers.ToList().Select(c => new
            {
                ctm_id = c.ctm_id,
                ctm_name = c.ctm_name + " " + c.ctm_surname
            }), "ctm_id", "ctm_name");

            return View();
        }

        [HttpPost]
        public ActionResult AddSale(tbl_sales sale)
        {
            if (ModelState.IsValid)
            {
                sale.sal_date = System.DateTime.Now.Date;
                db.tbl_sales.Add(sale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductForSales = new SelectList(db.tbl_products, "prd_id", "prd_name");
            ViewBag.StaffForSales = new SelectList(db.tbl_staff.ToList().Select(s => new
            {
                stf_id = s.stf_id,
                stf_name = s.stf_name + " " + s.stf_surname
            }), "stf_id", "stf_name");
            ViewBag.CustomerForSales = new SelectList(db.tbl_customers.ToList().Select(c => new
            {
                ctm_id = c.ctm_id,
                ctm_name = c.ctm_name + " " + c.ctm_surname
            }), "ctm_id", "ctm_name");
            return View(sale);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

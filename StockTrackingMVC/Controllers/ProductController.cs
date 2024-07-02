using StockTrackingMVC.Models.Entity;
using System.Linq;
using System.Web.Mvc;

namespace StockTrackingMVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            using (DB_StockTrackingMVCEntities db = new DB_StockTrackingMVCEntities())
            {
                var products = db.tbl_products.Include("tbl_categories").ToList();
                return View(products);
            }
        }

        // GET: AddProduct
        [HttpGet]
        public ActionResult AddProduct()
        {
            using (DB_StockTrackingMVCEntities db = new DB_StockTrackingMVCEntities())
            {
                ViewBag.CategoriesForProduct = new SelectList(db.tbl_categories.ToList(), "ctg_id", "ctg_name");
                return View();
            }
        }

        // POST: AddProduct
        [HttpPost]
        public ActionResult AddProduct(tbl_products product)
        {
            using (DB_StockTrackingMVCEntities db = new DB_StockTrackingMVCEntities())
            {
                db.tbl_products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}

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

        // AddProduct
        [HttpGet]
        public ActionResult AddProduct()
        {
            using (DB_StockTrackingMVCEntities db = new DB_StockTrackingMVCEntities())
            {
                ViewBag.CategoriesForProduct = new SelectList(db.tbl_categories.ToList(), "ctg_id", "ctg_name");
                return View();
            }
        }

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

        // EditProduct
        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            using (DB_StockTrackingMVCEntities db = new DB_StockTrackingMVCEntities())
            {
                ViewBag.CategoriesForProduct = new SelectList(db.tbl_categories.ToList(), "ctg_id", "ctg_name");
                var prod = db.tbl_products.Find(id);
                return View(prod);
            }
        }
        [HttpPost]
        public ActionResult EditProduct(tbl_products products)
        {
            using (DB_StockTrackingMVCEntities db = new DB_StockTrackingMVCEntities())
            {
                var value = db.tbl_products.Find(products.prd_id);
                value.prd_name = products.prd_name;
                value.prd_brand = products.prd_brand;
                value.prd_stock = products.prd_stock;
                value.prd_purchasePrice = products.prd_purchasePrice;
                value.prd_salePrice = products.prd_salePrice;
                value.prd_ctg_id = products.prd_ctg_id;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}

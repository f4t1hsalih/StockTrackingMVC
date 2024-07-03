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
                var products = db.tbl_products.Include("tbl_categories").Where(x => x.prd_status != false).ToList();
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
            if (ModelState.IsValid)
            {
                using (var db = new DB_StockTrackingMVCEntities())
                {
                    product.prd_status = true;

                    if (product.prd_purchasePrice == null)
                    {
                        product.prd_purchasePrice = 0;
                    }
                    if (product.prd_salePrice == null)
                    {
                        product.prd_salePrice = 0;
                    }
                    if (product.prd_stock == null)
                    {
                        product.prd_stock = 0;
                    }

                    db.tbl_products.Add(product);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            using (var db = new DB_StockTrackingMVCEntities())
            {
                ViewBag.CategoriesForProduct = new SelectList(db.tbl_categories.ToList(), "ctg_id", "ctg_name");
                return View(product);
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
                if (prod == null)
                {
                    return HttpNotFound();
                }
                return View(prod);
            }
        }

        [HttpPost]
        public ActionResult EditProduct(tbl_products products)
        {
            if (ModelState.IsValid)
            {
                using (DB_StockTrackingMVCEntities db = new DB_StockTrackingMVCEntities())
                {
                    var value = db.tbl_products.Find(products.prd_id);
                    if (value == null)
                    {
                        return HttpNotFound();
                    }
                    value.prd_name = products.prd_name;
                    value.prd_brand = products.prd_brand;
                    value.prd_stock = products.prd_stock;
                    value.prd_purchasePrice = products.prd_purchasePrice;
                    value.prd_salePrice = products.prd_salePrice;
                    value.prd_ctg_id = products.prd_ctg_id;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            using (DB_StockTrackingMVCEntities db = new DB_StockTrackingMVCEntities())
            {
                ViewBag.CategoriesForProduct = new SelectList(db.tbl_categories.ToList(), "ctg_id", "ctg_name", products.prd_ctg_id);
                return View(products);
            }
        }

        // DeleteProduct
        public ActionResult DeleteProduct(int id)
        {
            using (DB_StockTrackingMVCEntities db = new DB_StockTrackingMVCEntities())
            {
                var value = db.tbl_products.Find(id);
                if (value == null)
                {
                    return HttpNotFound();
                }
                value.prd_status = false;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}

using StockTrackingMVC.Models.Entity;
using System.Linq;
using System.Web.Mvc;

namespace StockTrackingMVC.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            using (DB_StockTrackingMVCEntities db = new DB_StockTrackingMVCEntities())
            {
                var categories = db.tbl_categories.ToList();
                return View(categories);
            }
        }


        // GET: Category/AddCategory
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(tbl_categories category)
        {
            using (DB_StockTrackingMVCEntities db = new DB_StockTrackingMVCEntities())
            {
                db.tbl_categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}
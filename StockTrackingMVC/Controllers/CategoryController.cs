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
                var categories = db.tbl_categories.Where(x => x.ctg_status != false).ToList();
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
                category.ctg_status = true;
                db.tbl_categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        //GET: Category/DeleteCategory
        public ActionResult DeleteCategory(int id)
        {
            using (DB_StockTrackingMVCEntities db = new DB_StockTrackingMVCEntities())
            {
                var category = db.tbl_categories.Find(id);
                category.ctg_status = false;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        //GET: Category/UpdateCategory
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            using (DB_StockTrackingMVCEntities db = new DB_StockTrackingMVCEntities())
            {
                var category = db.tbl_categories.Find(id);
                return View(category);
            }
        }
        [HttpPost]
        public ActionResult UpdateCategory(tbl_categories category)
        {
            using (DB_StockTrackingMVCEntities db = new DB_StockTrackingMVCEntities())
            {
                var updatedCategory = db.tbl_categories.Find(category.ctg_id);
                updatedCategory.ctg_name = category.ctg_name;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}
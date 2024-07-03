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
        [ValidateAntiForgeryToken]
        public ActionResult AddCategory(tbl_categories category)
        {
            if (ModelState.IsValid)
            {
                using (DB_StockTrackingMVCEntities db = new DB_StockTrackingMVCEntities())
                {
                    category.ctg_status = true;
                    db.tbl_categories.Add(category);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Category/DeleteCategory
        public ActionResult DeleteCategory(int id)
        {
            using (DB_StockTrackingMVCEntities db = new DB_StockTrackingMVCEntities())
            {
                var category = db.tbl_categories.Find(id);
                if (category == null)
                {
                    return HttpNotFound();
                }
                category.ctg_status = false;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Category/UpdateCategory
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            using (DB_StockTrackingMVCEntities db = new DB_StockTrackingMVCEntities())
            {
                var category = db.tbl_categories.Find(id);
                if (category == null)
                {
                    return HttpNotFound();
                }
                return View(category);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateCategory(tbl_categories category)
        {
            if (ModelState.IsValid)
            {
                using (DB_StockTrackingMVCEntities db = new DB_StockTrackingMVCEntities())
                {
                    var updatedCategory = db.tbl_categories.Find(category.ctg_id);
                    if (updatedCategory == null)
                    {
                        return HttpNotFound();
                    }
                    updatedCategory.ctg_name = category.ctg_name;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(category);
        }
    }
}

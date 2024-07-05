using StockTrackingMVC.Models.Entity;
using System.Linq;
using System.Web.Mvc;

namespace StockTrackingMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admins
        public ActionResult Index(string search)
        {
            using (DB_StockTrackingMVCEntities db = new DB_StockTrackingMVCEntities())
            {
                var admins = db.tbl_admins.Where(x => x.adm_status != false).ToList();
                if (!string.IsNullOrEmpty(search))
                {
                    admins = admins.Where(x => x.adm_username.Contains(search)).ToList();
                }
                return View(admins);
            }
        }

        // AddAdmin
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(tbl_admins admin)
        {
            using (DB_StockTrackingMVCEntities db = new DB_StockTrackingMVCEntities())
            {
                admin.adm_status = true;
                db.tbl_admins.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

    }
}
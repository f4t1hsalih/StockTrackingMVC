using StockTrackingMVC.Models.Entity;
using System.Linq;
using System.Web.Mvc;

namespace StockTrackingMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admins
        [Authorize]
        public ActionResult Index(string search)
        {
            string username = Session["Username"] as string;
            if (username == "kullanıcı1")
            {
                return RedirectToAction("Unauthorized", "Error"); // Yetkisiz erişim sayfasına yönlendirme
            }

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
        [Authorize]
        public ActionResult AddAdmin()
        {
            string username = Session["Username"] as string;
            if (username == "kullanıcı1")
            {
                return RedirectToAction("Unauthorized", "Error");
            }

            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddAdmin(tbl_admins admin)
        {
            string username = Session["Username"] as string;
            if (username == "kullanıcı1")
            {
                return RedirectToAction("Unauthorized", "Error");
            }

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

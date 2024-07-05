using StockTrackingMVC.Models.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace StockTrackingMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(tbl_admins user)
        {
            using (DB_StockTrackingMVCEntities db = new DB_StockTrackingMVCEntities())
            {
                var value = db.tbl_admins.Where(x => x.adm_username == user.adm_username && x.adm_password == user.adm_password && x.adm_status == true).FirstOrDefault();
                if (value != null)
                {
                    FormsAuthentication.SetAuthCookie(user.adm_username, false);
                    Session["Username"] = user.adm_username;
                    return RedirectToAction("Index", "Default");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı Adı Veya Şifre Yanlış.");
                    return View(user);
                }
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login", "Login");
        }
    }
}
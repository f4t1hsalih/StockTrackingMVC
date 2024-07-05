using StockTrackingMVC.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            //using (DB_StockTrackingMVCEntities db = new DB_StockTrackingMVCEntities())
            //{
            //    var value = db.tbl_admins.Where(user.adm_username == db.tbl_admins && user.adm_password ==);
            //        if (value.)
            //    {

            //    }
            //}
                return View();
        }
    }
}
using StockTrackingMVC.Models.Entity;
using System.Linq;
using System.Web.Mvc;

namespace StockTrackingMVC.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        public ActionResult Index()
        {
            using (DB_StockTrackingMVCEntities db = new DB_StockTrackingMVCEntities())
            {
                var staff = db.tbl_staff.Where(x => x.stf_status != false).ToList();
                return View(staff);
            }
        }

        // AddStaff
        [HttpGet]
        public ActionResult AddStaff()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStaff(tbl_staff staff)
        {
            if (ModelState.IsValid)
            {
                using (DB_StockTrackingMVCEntities db = new DB_StockTrackingMVCEntities())
                {
                    staff.stf_status = true;
                    db.tbl_staff.Add(staff);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View(staff);
            }
        }

        // UpdateStaff
        [HttpGet]
        public ActionResult UpdateStaff(int id)
        {
            using (DB_StockTrackingMVCEntities db = new DB_StockTrackingMVCEntities())
            {
                var staff = db.tbl_staff.Find(id);
                return View(staff);
            }
        }
        [HttpPost]
        public ActionResult UpdateStaff(tbl_staff staff)
        {
            if (ModelState.IsValid)
            {
                using (DB_StockTrackingMVCEntities db = new DB_StockTrackingMVCEntities())
                {
                    var updatedStaff = db.tbl_staff.Find(staff.stf_id);
                    updatedStaff.stf_name = staff.stf_name;
                    updatedStaff.stf_surname = staff.stf_surname;
                    updatedStaff.stf_department = staff.stf_department;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View(staff);
            }
        }

        // DeleteStaff
        public ActionResult DeleteStaff(int id)
        {
            using (DB_StockTrackingMVCEntities db = new DB_StockTrackingMVCEntities())
            {
                var staff = db.tbl_staff.Find(id);
                staff.stf_status = false;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

    }
}
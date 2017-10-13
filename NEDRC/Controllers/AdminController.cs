using NEDRC.Models;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace NEDRC.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext db;
        public AdminController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ApplicationUser user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(string id)
        {
            return View(db.Users.Find(id));
        }
    }
}
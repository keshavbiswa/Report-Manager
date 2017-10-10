using System.Net;
using System.Web.Mvc;
using NEDRC.Models;

namespace NEDRC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ManageUser()
        {
            return View();
        }
    }
}
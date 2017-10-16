using NEDRC.ViewModel;
using System.Net.Mail;
using System.Text;
using System.Web.Mvc;

namespace NEDRC.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Report Manager";

            return View();
        }

        
    }
}
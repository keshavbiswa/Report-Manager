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

        public ActionResult Contact()
        {
            ViewBag.Message = "Techzombo";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                StringBuilder message = new StringBuilder();
                MailAddress from = new MailAddress(viewModel.Email.ToString());
                message.Append("Name: " + viewModel.Name + "\n");
                message.Append("Email: " + viewModel.Email + "\n");
                message.Append("Subject: " + viewModel.Subject + "\n\n");
                message.Append(viewModel.Message);

                MailMessage mail = new MailMessage();

                SmtpClient smtp = new SmtpClient();

                smtp.Host = "smtp.mail.yahoo.com";
                smtp.Port = 465;

                System.Net.NetworkCredential credentials =
                    new System.Net.NetworkCredential("yahooaccount", "yahoopassword");

                smtp.Credentials = credentials;
                smtp.EnableSsl = true;

                mail.From = from;
                mail.To.Add("yahooemailaddress");
                mail.Subject = "Test enquiry from " + viewModel.Name;
                mail.Body = message.ToString();

                smtp.Send(mail);
            }
            return View();
        }
    }
}
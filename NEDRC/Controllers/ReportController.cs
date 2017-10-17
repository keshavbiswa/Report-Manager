using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNet.Identity;
using NEDRC.Models;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NEDRC.Controllers
{
    public class ReportController : Controller
    {
        private readonly ApplicationDbContext db;

        public ReportController()
        {
            db = new ApplicationDbContext();
        }

        // GET: Report
        public ActionResult Index()
        {
            var reports = db.Reports.OrderBy(m => m.IsApproved);
            return View(reports.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Reports reports, HttpPostedFileBase upload)
        {
            if (upload != null && upload.ContentLength > 0)
            {
                var reader = new System.IO.BinaryReader(upload.InputStream);
               
                var report = new Reports
                {
                    Name = reports.Name,
                    Date = DateTime.Now.ToShortDateString(),
                    IsApproved = reports.IsApproved,
                    Description = reports.Description,
                    Content = reader.ReadBytes(upload.ContentLength)

                };
                db.Reports.Add(report);
                reader.Close();
                db.SaveChanges();
                RedirectToAction("Index");
            }
            
            return RedirectToAction("Index");
        }
        // GET: Reports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reports reports = db.Reports.Find(id);
            if (reports == null)
            {
                return HttpNotFound();
            }
            return View(reports);
        }

        // POST: Reports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reports reports = db.Reports.Find(id);
            db.Reports.Remove(reports);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult View(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Reports reports = db.Reports.Find(id);

            if (reports != null)
            {
                var content = reports.Content;

                return File(content, "application/pdf");
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
        }

        // GET: Reports/ApproveResult/5
        public ActionResult ApproveResult(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reports reports = db.Reports.Find(id);
            if (reports == null)
            {
                return HttpNotFound();
            }
            return View(reports);
        }

        [Route("Report/Approve/{id}/")]
        // POST: Reports/Approve/5
        [HttpPost, ActionName("Approve")]
        [ValidateAntiForgeryToken]
        public ActionResult Approve(int? id)
        {
            ApplicationUser users = db.Users.Find(User.Identity.GetUserId());
            Reports reports = db.Reports.Find(id);

            if (reports == null || users == null) return View();

            byte[] content = reports.Content;
            byte[] signature = users.Signature;

            iTextSharp.text.Image sigImg = iTextSharp.text.Image.GetInstance(signature);

            PdfReader reader = new PdfReader(content);
            using (MemoryStream ms = new MemoryStream())
            {
                try
                {
                    PdfStamper stamper = new PdfStamper(reader, ms);

                    sigImg.SetAbsolutePosition(450f, 80f);

                    sigImg.ScalePercent(25.0f); // 100.0f == same size


                    //Give some space after the image
                    sigImg.SpacingAfter = 1f;
                    sigImg.Alignment = Element.ALIGN_BOTTOM;

                    PdfContentByte over = stamper.GetOverContent(1);

                    over.AddImage(sigImg);

                    stamper.Close();

                    reports.Content = ms.ToArray();
                    content = reports.Content;

                    reports.IsApproved = true;

                    db.SaveChanges();

                    reader.Close();

                    return File(content, "application/pdf");
                }
                catch
                {
                    return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                }
            }
        }
    }
}
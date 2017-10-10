using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NEDRC.Models;

namespace NEDRC.Controllers
{
    public class DemoModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DemoModels
        public ActionResult Index()
        {
            return View(db.DemoModels.ToList());
        }

        // GET: DemoModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DemoModel demoModel = db.DemoModels.Find(id);
            if (demoModel == null)
            {
                return HttpNotFound();
            }
            return View(demoModel);
        }

        // GET: DemoModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DemoModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] DemoModel demoModel)
        {
            if (ModelState.IsValid)
            {
                db.DemoModels.Add(demoModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(demoModel);
        }

        // GET: DemoModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DemoModel demoModel = db.DemoModels.Find(id);
            if (demoModel == null)
            {
                return HttpNotFound();
            }
            return View(demoModel);
        }

        // POST: DemoModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] DemoModel demoModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(demoModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(demoModel);
        }

        // GET: DemoModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DemoModel demoModel = db.DemoModels.Find(id);
            if (demoModel == null)
            {
                return HttpNotFound();
            }
            return View(demoModel);
        }

        // POST: DemoModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DemoModel demoModel = db.DemoModels.Find(id);
            db.DemoModels.Remove(demoModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

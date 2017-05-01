using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FootballFixturesApp1.DAL;
using FootballFixturesApp1.Models;

namespace FootballFixturesApp1.Controllers

{
    public class ReportController : Controller
    {
        private MatchContext db = new MatchContext();

        // GET: Reports
        public ActionResult Index()
        {
            return View(db.Reports.ToList());
        }

        // GET: Reports/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report reports = db.Reports.Find(id);
            if (reports == null)
            {
                return HttpNotFound();
            }
            return View(reports);
        }

        // GET: Reports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AReport")] Report reports)

        {

            try
            {

                if (ModelState.IsValid)
                {
                    db.Reports.Add(reports);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(reports);
        }


        // GET: Reports/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report reports = db.Reports.Find(id);
            if (reports == null)
            {
                return HttpNotFound();
            }
            return View(reports);
        }

        // POST: Reports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Report")] Report reports)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reports).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reports);
        }


        // GET: Fixtures/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report reports = db.Reports.Find(id);
            if (reports == null)
            {
                return HttpNotFound();
            }
            return View(reports);
        }

        // POST: Fixtures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Report reports = db.Reports.Find(id);
            db.Reports.Remove(reports);
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
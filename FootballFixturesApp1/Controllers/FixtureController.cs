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
    public class FixtureController : Controller
    {
        private MatchContext db = new MatchContext();

        // GET: Fixture
        public ActionResult Index(string search)

        {
            var fixtures = from f in db.Fixtures
                           select f;

            if (!String.IsNullOrEmpty(search))
            {
                fixtures = fixtures.Where(f => f.TeamOne.Contains(search) || f.TeamTwo.Contains(search));
               
            }

            return View(fixtures);
        }





        // GET: Fixtures/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fixture fixtures = db.Fixtures.Find(id);
            if (fixtures == null)
            {
                return HttpNotFound();
            }
            return View(fixtures);
        }

        // GET: Fixtures/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Fixtures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Date,TeamOne,TeamTwo,Result")] Fixture fixtures)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Fixtures.Add(fixtures);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(fixtures);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        // GET: Fixtures/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fixture fixtures = db.Fixtures.Find(id);
            if (fixtures == null)
            {
                return HttpNotFound();
            }
            return View(fixtures);
        }

        // POST: Fixtures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Date,TeamOne,TeamTwo,Result")] Fixture fixtures)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fixtures).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fixtures);
        }

        // GET: Fixtures/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fixture fixtures = db.Fixtures.Find(id);
            if (fixtures == null)
            {
                return HttpNotFound();
            }
            return View(fixtures);
        }

        // POST: Fixtures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Fixture fixtures = db.Fixtures.Find(id);
            db.Fixtures.Remove(fixtures);
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
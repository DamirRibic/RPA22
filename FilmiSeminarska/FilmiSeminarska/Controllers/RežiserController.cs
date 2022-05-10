using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FilmiSeminarska.Data;
using Seminarska.Models;

namespace FilmiSeminarska.Controllers
{
    public class RežiserController : Controller
    {
        private FilmiSeminarskaContext db = new FilmiSeminarskaContext();

        // GET: Režiser
        public ActionResult Index()
        {
            return View(db.Režiser.ToList());
        }

        // GET: Režiser/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Režiser režiser = db.Režiser.Find(id);
            if (režiser == null)
            {
                return HttpNotFound();
            }
            return View(režiser);
        }

        // GET: Režiser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Režiser/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Ime")] Režiser režiser)
        {
            if (ModelState.IsValid)
            {
                db.Režiser.Add(režiser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(režiser);
        }

        // GET: Režiser/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Režiser režiser = db.Režiser.Find(id);
            if (režiser == null)
            {
                return HttpNotFound();
            }
            return View(režiser);
        }

        // POST: Režiser/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Ime")] Režiser režiser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(režiser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(režiser);
        }

        // GET: Režiser/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Režiser režiser = db.Režiser.Find(id);
            if (režiser == null)
            {
                return HttpNotFound();
            }
            return View(režiser);
        }

        // POST: Režiser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Režiser režiser = db.Režiser.Find(id);
            db.Režiser.Remove(režiser);
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

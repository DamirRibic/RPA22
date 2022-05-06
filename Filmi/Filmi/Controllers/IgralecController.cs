using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Filmi.Data;
using Seminarska.Models;

namespace Filmi.Controllers
{
    public class IgralecController : Controller
    {
        private FilmiContext db = new FilmiContext();

        // GET: Igralec
        public ActionResult Index()
        {
            var igralecs = db.Igralecs.Include(i => i.Film);
            return View(igralecs.ToList());
        }

        // GET: Igralec/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Igralec igralec = db.Igralecs.Find(id);
            if (igralec == null)
            {
                return HttpNotFound();
            }
            return View(igralec);
        }

        // GET: Igralec/Create
        public ActionResult Create()
        {
            ViewBag.Filmid = new SelectList(db.Films, "id", "Ime");
            return View();
        }

        // POST: Igralec/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Ime,Priimek,Filmid")] Igralec igralec)
        {
            if (ModelState.IsValid)
            {
                db.Igralecs.Add(igralec);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Filmid = new SelectList(db.Films, "id", "Ime", igralec.Filmid);
            return View(igralec);
        }

        // GET: Igralec/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Igralec igralec = db.Igralecs.Find(id);
            if (igralec == null)
            {
                return HttpNotFound();
            }
            ViewBag.Filmid = new SelectList(db.Films, "id", "Ime", igralec.Filmid);
            return View(igralec);
        }

        // POST: Igralec/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Ime,Priimek,Filmid")] Igralec igralec)
        {
            if (ModelState.IsValid)
            {
                db.Entry(igralec).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Filmid = new SelectList(db.Films, "id", "Ime", igralec.Filmid);
            return View(igralec);
        }

        // GET: Igralec/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Igralec igralec = db.Igralecs.Find(id);
            if (igralec == null)
            {
                return HttpNotFound();
            }
            return View(igralec);
        }

        // POST: Igralec/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Igralec igralec = db.Igralecs.Find(id);
            db.Igralecs.Remove(igralec);
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

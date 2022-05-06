using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Seminarska.Data;
using Seminarska.Models;

namespace Seminarska.Controllers
{
    public class IgralciController : Controller
    {
        private SeminarskaContext db = new SeminarskaContext();

        // GET: Igralci
        public ActionResult Index()
        {
            return View(db.Igralcis.ToList());
        }

        // GET: Igralci/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Igralci igralci = db.Igralcis.Find(id);
            if (igralci == null)
            {
                return HttpNotFound();
            }
            return View(igralci);
        }

        // GET: Igralci/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Igralci/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Ime,Priimek,Filmiid")] Igralci igralci)
        {
            if (ModelState.IsValid)
            {
                db.Igralcis.Add(igralci);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(igralci);
        }

        // GET: Igralci/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Igralci igralci = db.Igralcis.Find(id);
            if (igralci == null)
            {
                return HttpNotFound();
            }
            return View(igralci);
        }

        // POST: Igralci/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Ime,Priimek,Filmiid")] Igralci igralci)
        {
            if (ModelState.IsValid)
            {
                db.Entry(igralci).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(igralci);
        }

        // GET: Igralci/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Igralci igralci = db.Igralcis.Find(id);
            if (igralci == null)
            {
                return HttpNotFound();
            }
            return View(igralci);
        }

        // POST: Igralci/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Igralci igralci = db.Igralcis.Find(id);
            db.Igralcis.Remove(igralci);
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

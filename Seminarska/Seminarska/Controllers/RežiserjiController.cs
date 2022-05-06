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
    public class RežiserjiController : Controller
    {
        private SeminarskaContext db = new SeminarskaContext();

        // GET: Režiserji
        public ActionResult Index()
        {
            return View(db.Režiserji.ToList());
        }

        // GET: Režiserji/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Režiserji režiserji = db.Režiserji.Find(id);
            if (režiserji == null)
            {
                return HttpNotFound();
            }
            return View(režiserji);
        }

        // GET: Režiserji/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Režiserji/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Ime,Priimek")] Režiserji režiserji)
        {
            if (ModelState.IsValid)
            {
                db.Režiserji.Add(režiserji);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(režiserji);
        }

        // GET: Režiserji/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Režiserji režiserji = db.Režiserji.Find(id);
            if (režiserji == null)
            {
                return HttpNotFound();
            }
            return View(režiserji);
        }

        // POST: Režiserji/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Ime,Priimek")] Režiserji režiserji)
        {
            if (ModelState.IsValid)
            {
                db.Entry(režiserji).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(režiserji);
        }

        // GET: Režiserji/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Režiserji režiserji = db.Režiserji.Find(id);
            if (režiserji == null)
            {
                return HttpNotFound();
            }
            return View(režiserji);
        }

        // POST: Režiserji/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Režiserji režiserji = db.Režiserji.Find(id);
            db.Režiserji.Remove(režiserji);
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

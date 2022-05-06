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
    public class FilmiController : Controller
    {
        private SeminarskaContext db = new SeminarskaContext();

        // GET: Filmi
        public ActionResult Index()
        {
            return View(db.Filmis.ToList());
        }

        // GET: Filmi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filmi filmi = db.Filmis.Find(id);
            if (filmi == null)
            {
                return HttpNotFound();
            }
            return View(filmi);
        }

        // GET: Filmi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Filmi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Ime,Žanra,LetoIzdaje,Režiserjiid")] Filmi filmi)
        {
            if (ModelState.IsValid)
            {
                db.Filmis.Add(filmi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(filmi);
        }

        // GET: Filmi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filmi filmi = db.Filmis.Find(id);
            if (filmi == null)
            {
                return HttpNotFound();
            }
            return View(filmi);
        }

        // POST: Filmi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Ime,Žanra,LetoIzdaje,Režiserjiid")] Filmi filmi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(filmi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(filmi);
        }

        // GET: Filmi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filmi filmi = db.Filmis.Find(id);
            if (filmi == null)
            {
                return HttpNotFound();
            }
            return View(filmi);
        }

        // POST: Filmi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Filmi filmi = db.Filmis.Find(id);
            db.Filmis.Remove(filmi);
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

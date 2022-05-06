﻿using System;
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
    public class FilmController : Controller
    {
        private FilmiContext db = new FilmiContext();

        // GET: Film
        public ActionResult Index()
        {
            var films = db.Films.Include(f => f.Režiser);
            return View(films.ToList());
        }

        // GET: Film/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Films.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // GET: Film/Create
        public ActionResult Create()
        {
            ViewBag.Režiserid = new SelectList(db.Režiser, "id", "Ime");
            return View();
        }

        // POST: Film/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Ime,Žanra,LetoIzdaje,Režiserid")] Film film)
        {
            if (ModelState.IsValid)
            {
                db.Films.Add(film);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Režiserid = new SelectList(db.Režiser, "id", "Ime", film.Režiserid);
            return View(film);
        }

        // GET: Film/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Films.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            ViewBag.Režiserid = new SelectList(db.Režiser, "id", "Ime", film.Režiserid);
            return View(film);
        }

        // POST: Film/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Ime,Žanra,LetoIzdaje,Režiserid")] Film film)
        {
            if (ModelState.IsValid)
            {
                db.Entry(film).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Režiserid = new SelectList(db.Režiser, "id", "Ime", film.Režiserid);
            return View(film);
        }

        // GET: Film/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Films.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // POST: Film/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Film film = db.Films.Find(id);
            db.Films.Remove(film);
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

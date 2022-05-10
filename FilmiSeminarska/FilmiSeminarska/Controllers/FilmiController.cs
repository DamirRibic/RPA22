using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FilmiSeminarska.Data;
using Seminarska.Models;

namespace FilmiSeminarska.Controllers
{
    public class FilmiController : ApiController
    {
        private FilmiSeminarskaContext db = new FilmiSeminarskaContext();

        // GET: api/Filmi
        public IQueryable<Film> GetFilms()
        {
            return db.Films;
        }

        // GET: api/Filmi/5
        [ResponseType(typeof(Film))]
        public IHttpActionResult GetFilm(int id)
        {
            Film film = db.Films.Find(id);
            if (film == null)
            {
                return NotFound();
            }

            return Ok(film);
        }

        // PUT: api/Filmi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFilm(int id, Film film)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != film.id)
            {
                return BadRequest();
            }

            db.Entry(film).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Filmi
        [ResponseType(typeof(Film))]
        public IHttpActionResult PostFilm(Film film)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Films.Add(film);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = film.id }, film);
        }

        // DELETE: api/Filmi/5
        [ResponseType(typeof(Film))]
        public IHttpActionResult DeleteFilm(int id)
        {
            Film film = db.Films.Find(id);
            if (film == null)
            {
                return NotFound();
            }

            db.Films.Remove(film);
            db.SaveChanges();

            return Ok(film);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FilmExists(int id)
        {
            return db.Films.Count(e => e.id == id) > 0;
        }
    }
}
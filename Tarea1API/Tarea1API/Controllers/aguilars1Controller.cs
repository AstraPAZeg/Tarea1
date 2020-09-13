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
using Tarea1API.Models;

namespace Tarea1API.Controllers
{
    public class aguilars1Controller : ApiController
    {
        private DataContext db = new DataContext();
        [Authorize]
        // GET: api/aguilars1
        public IQueryable<aguilar> Getaguilars()
        {
            return db.Students;
        }
        [Authorize]
        // GET: api/aguilars1/5
        [ResponseType(typeof(aguilar))]
        public IHttpActionResult Getaguilar(int id)
        {
            aguilar aguilar = db.Students.Find(id);
            if (aguilar == null)
            {
                return NotFound();
            }

            return Ok(aguilar);
        }
        [Authorize]
        // PUT: api/aguilars1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putaguilar(int id, aguilar aguilar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aguilar.aguilar_ID)
            {
                return BadRequest();
            }

            db.Entry(aguilar).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!aguilarExists(id))
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
        [Authorize]
        // POST: api/aguilars1
        [ResponseType(typeof(aguilar))]
        public IHttpActionResult Postaguilar(aguilar aguilar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Students.Add(aguilar);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = aguilar.aguilar_ID }, aguilar);
        }
        [Authorize]
        // DELETE: api/aguilars1/5
        [ResponseType(typeof(aguilar))]
        public IHttpActionResult Deleteaguilar(int id)
        {
            aguilar aguilar = db.Students.Find(id);
            if (aguilar == null)
            {
                return NotFound();
            }

            db.Students.Remove(aguilar);
            db.SaveChanges();

            return Ok(aguilar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool aguilarExists(int id)
        {
            return db.Students.Count(e => e.aguilar_ID == id) > 0;
        }
    }
}
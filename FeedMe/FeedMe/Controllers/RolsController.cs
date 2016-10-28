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
using FeedMe;

namespace FeedMe.Controllers
{
    public class RolsController : ApiController
    {
        private FeedMeEntities db = new FeedMeEntities();

        // GET: api/Rols
        public IQueryable<Rol> GetRols()
        {
            return db.Rols;
        }

        // GET: api/Rols/5
        [ResponseType(typeof(Rol))]
        public IHttpActionResult GetRol(int id)
        {
            Rol rol = db.Rols.Find(id);
            if (rol == null)
            {
                return NotFound();
            }

            return Ok(rol);
        }

        // PUT: api/Rols/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRol(int id, Rol rol)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rol.RoleId)
            {
                return BadRequest();
            }

            db.Entry(rol).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolExists(id))
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

        // POST: api/Rols
        [ResponseType(typeof(Rol))]
        public IHttpActionResult PostRol(Rol rol)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rols.Add(rol);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = rol.RoleId }, rol);
        }

        // DELETE: api/Rols/5
        [ResponseType(typeof(Rol))]
        public IHttpActionResult DeleteRol(int id)
        {
            Rol rol = db.Rols.Find(id);
            if (rol == null)
            {
                return NotFound();
            }

            db.Rols.Remove(rol);
            db.SaveChanges();

            return Ok(rol);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RolExists(int id)
        {
            return db.Rols.Count(e => e.RoleId == id) > 0;
        }
    }
}
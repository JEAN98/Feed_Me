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
    public class PeriodTypesController : ApiController
    {
        private FeedMeEntities db = new FeedMeEntities();

        // GET: api/PeriodTypes
        public IQueryable<PeriodType> GetPeriodTypes()
        {
            return db.PeriodTypes;
        }

        // GET: api/PeriodTypes/5
        [ResponseType(typeof(PeriodType))]
        public IHttpActionResult GetPeriodType(int id)
        {
            PeriodType periodType = db.PeriodTypes.Find(id);
            if (periodType == null)
            {
                return NotFound();
            }

            return Ok(periodType);
        }

        // PUT: api/PeriodTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPeriodType(int id, PeriodType periodType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != periodType.PeriodId)
            {
                return BadRequest();
            }

            db.Entry(periodType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeriodTypeExists(id))
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

        // POST: api/PeriodTypes
        [ResponseType(typeof(PeriodType))]
        public IHttpActionResult PostPeriodType(PeriodType periodType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PeriodTypes.Add(periodType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = periodType.PeriodId }, periodType);
        }

        // DELETE: api/PeriodTypes/5
        [ResponseType(typeof(PeriodType))]
        public IHttpActionResult DeletePeriodType(int id)
        {
            PeriodType periodType = db.PeriodTypes.Find(id);
            if (periodType == null)
            {
                return NotFound();
            }

            db.PeriodTypes.Remove(periodType);
            db.SaveChanges();

            return Ok(periodType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PeriodTypeExists(int id)
        {
            return db.PeriodTypes.Count(e => e.PeriodId == id) > 0;
        }
    }
}
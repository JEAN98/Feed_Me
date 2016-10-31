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
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using QRCoder;

namespace FeedMe.Controllers
{
    public class FeedBacksController : ApiController
    {
        private FeedMeEntities db = new FeedMeEntities();

        // GET: api/FeedBacks
        public IQueryable<FeedBack> GetFeedBacks()
        {
            return db.FeedBacks;
        }

        // GET: api/FeedBacks/5
        [ResponseType(typeof(FeedBack))]
        public IHttpActionResult GetFeedBack(int id)
        {
            FeedBack feedBack = db.FeedBacks.Find(id);
            if (feedBack == null)
            {
                return NotFound();
            }

            return Ok(feedBack);
        }

        // PUT: api/FeedBacks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFeedBack(int id, FeedBack feedBack)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != feedBack.FeedBackId)
            {
                return BadRequest();
            }

            db.Entry(feedBack).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedBackExists(id))
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

        // POST: api/FeedBacks
        [ResponseType(typeof(FeedBack))]
        public IHttpActionResult PostFeedBack(FeedBack feedBack)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FeedBacks.Add(feedBack);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = feedBack.FeedBackId }, feedBack);
        }

        // DELETE: api/FeedBacks/5
        [ResponseType(typeof(FeedBack))]
        public IHttpActionResult DeleteFeedBack(int id)
        {
            FeedBack feedBack = db.FeedBacks.Find(id);
            if (feedBack == null)
            {
                return NotFound();
            }

            db.FeedBacks.Remove(feedBack);
            db.SaveChanges();

            return Ok(feedBack);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FeedBackExists(int id)
        {
            return db.FeedBacks.Count(e => e.FeedBackId == id) > 0;
        }

        public IEnumerable<FeedBack> GraphBy0(string startDate, string endDate, int storeId)
        {
            List<FeedBack> result;

            try
            {
                var splitValues0 = startDate.Split('-').Select(x => Int32.Parse(x));
                var start = new DateTime(splitValues0.ElementAt(0), splitValues0.ElementAt(01), splitValues0.ElementAt(02));

                var splitValues1 = endDate.Split('-').Select(x => Int32.Parse(x));
                var end = new DateTime(splitValues1.ElementAt(0), splitValues1.ElementAt(01), splitValues1.ElementAt(02));

                result = db.FeedBacks
                    .Where(x => x.StoreId == storeId && x.CreationDate >= start &&
                    x.CreationDate <= end && x.Face == 0)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }

            return result;
        }
        public IEnumerable<FeedBack> GraphBy1(string startDate, string endDate, int storeId)
        {
            var result = new List<FeedBack>();

            try
            {
                var splitValues0 = startDate.Split('-').Select(x => Int32.Parse(x));
                var start = new DateTime(splitValues0.ElementAt(0), splitValues0.ElementAt(01),
                    splitValues0.ElementAt(02));

                var splitValues1 = endDate.Split('-').Select(x => Int32.Parse(x));
                var end = new DateTime(splitValues1.ElementAt(0), splitValues1.ElementAt(01), splitValues1.ElementAt(02));


                result = db.FeedBacks
                  .Where(x => x.StoreId == storeId && x.CreationDate >= start &&
                              x.CreationDate <= end && x.Face == 1)
                  .ToList();

            }
            catch (Exception exception)
            {
                throw new InvalidOperationException(exception.Message);
            }
            return result;
        }
        public List<string> GetOpinions(string start, string end, int storeId)
        {
            List<string> listOpinons = null;
            try
            {
                IEnumerable<FeedBack> List1 = GraphBy1(start, end, storeId);
                IEnumerable<FeedBack> List2 = GraphBy1(start, end, storeId);
                if (List1 == null || List2 == null)
                {
                    throw new Exception("You must to write the information about the datetime");
                }

                foreach (var feedback in List1)
                {
                    if (feedback.Opinion != null)
                        listOpinons.Add(feedback.Opinion);
                }

                foreach (var feedback in List2)
                {
                    if (feedback.Opinion != null)
                        listOpinons.Add(feedback.Opinion);
                }

                if (listOpinons == null)
                    return null;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return listOpinons;
        }

        public void GetGraph(string start, string end, int storeId)
        {
            try
            {
                IEnumerable<FeedBack> List1 = GraphBy1(start, end, storeId);
                IEnumerable<FeedBack> List2 = GraphBy1(start, end, storeId);
                if (List1 == null || List2 == null)
                {
                    throw new Exception("You must to write the information about datetime");
                }
                var Happy = List1.Count();
                var Sad = List2.Count();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
      
    }
}
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
    public class CouponsController : ApiController
    {
        private FeedMeEntities db = new FeedMeEntities();
       
        // GET: api/Coupons
        public IQueryable<Coupon> GetCoupons()
        {
            return db.Coupons;
        }
        
        // GET: api/Coupons/5
        [ResponseType(typeof(Coupon))]
        public IHttpActionResult GetCoupon(int id)
        {
            Coupon coupon = db.Coupons.Find(id);
            if (coupon == null)
            {
                return NotFound();
            }

            return Ok(coupon);
        }

        // PUT: api/Coupons/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCoupon(int id, Coupon coupon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != coupon.CouponId)
            {
                return BadRequest();
            }

            db.Entry(coupon).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CouponExists(id))
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

        // POST: api/Coupons
        [ResponseType(typeof(Coupon))]
        public IHttpActionResult PostCoupon(Coupon coupon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Coupons.Add(coupon);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = coupon.CouponId }, coupon);
        }

        // DELETE: api/Coupons/5
        [ResponseType(typeof(Coupon))]
        public IHttpActionResult DeleteCoupon(int id)
        {
            Coupon coupon = db.Coupons.Find(id);
            if (coupon == null)
            {
                return NotFound();
            }

            db.Coupons.Remove(coupon);
            db.SaveChanges();

            return Ok(coupon);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CouponExists(int id)
        {
            return db.Coupons.Count(e => e.CouponId == id) > 0;
        }


        public void ExchangeCoupon(string email, int storeId)
        {
            UsersController usercinController= new UsersController();
            if (usercinController.EmailReview(email) == 0)
            {
                User user = new User();

                user.Email = email;
                user.Passwordkey = "0000";
                user.RoleId = 1;
                usercinController.PostUser(user);

                Coupon coupon = new Coupon();

                Store store = db.Stores.Find(storeId);
                if (store == null)
                {
                    throw new InvalidOperationException("You must to insert a Store information before make this!");
                }
                coupon.Email = user.Email;
                coupon.StoreId = store.StoreId;
                coupon.Discount = store.Discount;
                coupon.ActivationStatus = 1;
                coupon.DiscountDescription = store.ProductDescription;
                coupon.PeriodId = store.PeriodId;

                PostCoupon(coupon);


            }
        }



    }
}
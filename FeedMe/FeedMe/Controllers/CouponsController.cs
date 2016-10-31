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

            return CreatedAtRoute("DefaultApi", new {id = coupon.CouponId}, coupon);
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

        //DesactivarCouponv fix this
        public bool DeactivateCoupon(int cuoponId)
        {
            Coupon cuopon = db.Coupons.Find(cuoponId);

            if (cuopon == null)
                return false;

            DateTime ?valiDateTime = cuopon.CreateDateTime;
                
            int ?caseSwitch = cuopon.PeriodId;

            
            //1= horas , 2=días, 3=Semanas,4=Meses
            switch (caseSwitch)
            {
                case 1:
                   
                    break;
                case 2:
                   
                    break;
                default:
                   
                    break;
                case 3:
                   
                    break;
                case 4:
                   
                    break;
            }

            return true;
        }

        public List<Coupon> GetCouponsByUserStatusActive(int userId)
        {
            return db.Coupons
                    .Where(x => x.UserId == userId && x.ActivationStatus == 1).ToList();
                //Devuelve una lista de los cupones que tiene activo
        }

        public bool ExchangeCoupon(string email, int storeId)
        {
            User user = new User();
            UsersController usercinController = new UsersController();
            Coupon coupon = new Coupon();
            Store store = db.Stores.Find(storeId);

            try
            {
                user= usercinController.EmailReview(email); //obtiene el usuario  a través del email que ya existe en la base de datos o que no existe para guardarlo
                if ( user== null)
                {

                    if (store == null)
                    {
                        throw new InvalidOperationException("You must to insert a Store information does not exist");
                    }
                    user.Email = email;
                    user.Passwordkey = "0000";
                    user.RoleId = 1;  //1=client, 2=users,3=Admin
                    user.StoreId = storeId;

                    db.Users.Add(user); //Lo inserta en la base de datos

                    coupon.Email = user.Email;
                    coupon.UserId = user.UserId;
                    coupon.StoreId = store.StoreId;
                    coupon.Discount = store.Discount;
                    coupon.ActivationStatus = 1;
                    coupon.DiscountDescription = store.ProductDescription;
                    coupon.PeriodId = store.PeriodId;
                    coupon.CreateDateTime = DateTime.Today;

                    PostCoupon(coupon); //Asigna un copon para el usuario
                    return true;
                }
                else
                {
                     if (GetCouponsByUserStatusActive(user.UserId) != null) //Verifca si tiene cupones activos
                    {
                        //Si no tiene ningún cupón activo
                        coupon.Email = user.Email;
                        coupon.UserId = user.UserId;
                        coupon.StoreId = store.StoreId;
                        coupon.Discount = store.Discount;
                        coupon.ActivationStatus = 1;
                        coupon.DiscountDescription = store.ProductDescription;
                        coupon.PeriodId = store.PeriodId;
                        coupon.CreateDateTime = DateTime.Today;

                        PostCoupon(coupon); //Asigna el copon para el usuario
                        return true;
                    }
                    //Sino es porque ya tiene algún cupón activo
                }
            }
            catch (Exception exception)
            {
                throw new System.InvalidOperationException("" + exception);
            }
            return false;
            }

        //Obtiene todos los cupones segun el storeId
        public List<Coupon> GetAllCuponByStore(int storeId)
        {
            return db.Coupons
                .Where(x => x.StoreId == storeId).ToList();
        }
    }
}
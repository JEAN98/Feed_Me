using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;
using FeedMe;

namespace FeedMe.Controllers
{
    public class UsersController : ApiController
    {
        private FeedMeEntities db = new FeedMeEntities();

        // GET: api/Users
        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserId)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new {id = user.UserId}, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.UserId == id) > 0;
        }

        public int EmailReview(string email)
        {
            List<User> userList = new List<User>();

            userList = GetUsers().ToList();
            try
            {
                foreach (var user in userList)
                {
                    if (user.Email == email)
                    {
                        return user.UserId;
                    }
                }
            }
            catch (Exception exception)
            {
                // ignored
                throw new InvalidOperationException(exception.Message);
            }
            return 0;
        }

        [ResponseType(typeof(string))]
        public IHttpActionResult InsertingPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return Content(HttpStatusCode.NotFound, "You must to write a password");
            }
            if (password.Length > 10)
            {
                return Content(HttpStatusCode.NotFound, "The password must be less than ten characters");
            }
            else
            {
                PasswordEncrypt(password);
                //Then insert into data base , pero el post user solo resive un dato de que es "User"
            }
            return Content(HttpStatusCode.Accepted, "Ready!");
        }


        //Incriptar contraseña
        [ResponseType(typeof(string))]
        public string PasswordEncrypt(string password)
        {
            MD5CryptoServiceProvider encrypted = new MD5CryptoServiceProvider();
            byte[] plainbytes = Encoding.ASCII.GetBytes(password);

            encrypted.ComputeHash(plainbytes);

            byte[] hashBytes = encrypted.Hash;

            string encryptedPassword = BitConverter.ToString(hashBytes);

            return encryptedPassword;
        }


        //PasswordReview
        [ResponseType(typeof(string))]
        public bool PasswordReview(User user, string password)
        {
            if (user.Passwordkey == PasswordEncrypt(password))
                return true;

            return false;
        }

      
    }
}
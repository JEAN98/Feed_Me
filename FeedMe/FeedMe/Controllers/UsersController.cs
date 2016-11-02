using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Security;
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

        public User EmailReview(string email)
        {
            List<User> userList = new List<User>();

            userList = GetUsers().ToList();
            try
            {
                foreach (var user in userList)
                {
                    if (user.Email == email)
                    {
                        return user;
                    }
                }
            }
            catch (Exception exception)
            {
                // ignored
                throw new InvalidOperationException(exception.Message);
            }
            return null;
        }

        //Modificar Usuarios
        [ResponseType(typeof(string))]
        public IHttpActionResult ModifyProfiles(User user, string newEmail, string newpassword)
        {
            User modifyUser = EmailReview(user.Email);
            try
            {
                if (EmailReview(newEmail) != null)
                {
                    return Content(HttpStatusCode.NotFound,
                        "You must to write a other email,because " + newEmail + " email exist in the database");
                }
                if (string.IsNullOrEmpty(newpassword))
                {
                    return Content(HttpStatusCode.NotFound, "You must to write a password");
                }
                if (newpassword.Length > 10)
                {
                    return Content(HttpStatusCode.NotFound, "The password must be less than ten characters");
                }
                if (user.Passwordkey != PasswordEncrypt(user.Passwordkey))
                {
                    return Content(HttpStatusCode.NotFound, "The password not match");
                }

                modifyUser.Email = newEmail;
                modifyUser.Passwordkey = PasswordEncrypt(newpassword);
                modifyUser.RoleId = user.RoleId;
                modifyUser.Rol = user.Rol;
                modifyUser.StoreId = user.StoreId;
                modifyUser.Store = user.Store;

                PutUser(modifyUser.UserId, modifyUser);
            }
            catch (Exception)
            {
                throw;
            }
            return Content(HttpStatusCode.NotFound, "The email information has been updated in the data base");
        }

        //Insertar usuarios según su roleId
        [ResponseType(typeof(string))]
        public IHttpActionResult InsertingUser(User insertuser)
        {
            //Rol rol = db.Rols.Find(insertuser.RoleId);
            //Store store = db.Stores.Find(insertuser.StoreId);
            try
             {
                if (string.IsNullOrEmpty(insertuser.Passwordkey))
                {
                    return Content(HttpStatusCode.NotFound, "You must to write a password");
                }
                if (insertuser.Passwordkey.Length > 10)
                {
                    return Content(HttpStatusCode.NotFound, "The password must be less than ten characters");
                }

                if (EmailReview(insertuser.Email) == null) //Para verficar si el email esta bien escrito ,se hará a nivel UI
                {
                    if (insertuser.RoleId == 2 || insertuser.RoleId == 3)
                        {
                             insertuser.Passwordkey = PasswordEncrypt(insertuser.Passwordkey);
                                    PostUser(insertuser);

                                return Content(HttpStatusCode.Accepted, "Ready!");
                        }
                      else
                         {
                             insertuser.Passwordkey = PasswordEncrypt("000");
                                PostUser(insertuser);

                                return Content(HttpStatusCode.Accepted, "Ready!");
                         }
              } 

            }
            catch (Exception exception)
           {

                throw;
            }
            return Content(HttpStatusCode.NotFound, "The email exist in the database,you must to write other email!");
       }

       //Restaurar contraseña
        public void Forgotpassword(string userEmail)
        {
            
        }
        //Incriptar contraseña
        [ResponseType(typeof(string))]
        private string PasswordEncrypt(string password)
        {
            SHA512Managed HashTool = new SHA512Managed();
            Byte[] PhraseAsByte = System.Text.Encoding.UTF8.GetBytes(string.Concat(password));
            Byte[] EncryptedPassword = HashTool.ComputeHash(PhraseAsByte);
            HashTool.Clear();

            return Convert.ToBase64String(EncryptedPassword);
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
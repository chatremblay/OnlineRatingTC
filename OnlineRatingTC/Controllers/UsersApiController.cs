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
using OnlineRatingTC.Models;

namespace OnlineRatingTC.Controllers
{
    public class UsersApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/UsersApi
        public HttpResponseMessage GetReviewUsers()
        {
            var userTypes = db.ReviewUsers.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, userTypes, Configuration.Formatters.JsonFormatter);
        }

        // GET: api/UsersApi/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = db.ReviewUsers.Find(id);
            if (user == null)
            {
                return Ok(new User());
            }
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
            return db.ReviewUsers.Count(e => e.UserId == id) > 0;
        }
    }
}
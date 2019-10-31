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
    public class ReviewRatingTypesApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ReviewRatingTypesApi
        public HttpResponseMessage GetReviewRatingTypes()
        {
            var reviewTypes = db.ReviewRatingTypes.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, reviewTypes, Configuration.Formatters.JsonFormatter);
        }

        // GET: api/ReviewRatingTypesApi/5
        [ResponseType(typeof(ReviewRatingType))]
        public IHttpActionResult GetReviewRatingType(int id)
        {
            ReviewRatingType reviewRatingType = db.ReviewRatingTypes.Find(id);
            if (reviewRatingType == null)
            {
                return NotFound();
            }
            return Ok(reviewRatingType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReviewRatingTypeExists(int id)
        {
            return db.ReviewRatingTypes.Count(e => e.ReviewRatingTypeCd == id) > 0;
        }
    }
}
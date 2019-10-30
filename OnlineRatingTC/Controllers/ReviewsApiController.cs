using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using OnlineRatingTC.Models;
using OnlineRatingTC.Services;

namespace OnlineRatingTC.Controllers
{
    public class ReviewsApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ReviewsApi
        [System.Web.Mvc.AllowAnonymous]
        public HttpResponseMessage GetReviews()
        {
            var reviewService = new ReviewServices(db);
            var reviews = reviewService.GetListOfReviews();
            return Request.CreateResponse(HttpStatusCode.OK, reviews, Configuration.Formatters.JsonFormatter);
        }

        // GET: api/ReviewsApi/5
        [System.Web.Mvc.AllowAnonymous]
        [ResponseType(typeof(Review))]
        public IHttpActionResult GetReview(int id)
        {
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return NotFound();
            }

            return Ok(review);
        }

        // PUT: api/ReviewsApi/5
        [System.Web.Mvc.AllowAnonymous]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReview(int id, Review review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != review.ReviewsId)
            {
                return BadRequest();
            }

            db.Entry(review).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(id))
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

        // POST: api/ReviewsApi
        [System.Web.Mvc.AllowAnonymous]
        [ResponseType(typeof(Review))]
        public IHttpActionResult PostReview(Review review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Reviews.Add(review);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = review.ReviewsId }, review);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReviewExists(int id)
        {
            return db.Reviews.Count(e => e.ReviewsId == id) > 0;
        }
    }
}
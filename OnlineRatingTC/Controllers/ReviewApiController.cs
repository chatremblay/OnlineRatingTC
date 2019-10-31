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
    public class ReviewApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ReviewApi
        public IQueryable<Review> GetReviews()
        {
            return db.Reviews;
        }

        // GET: api/ReviewApi/5
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

        //POST: api/ReviewApi
        [ResponseType(typeof(Review))]
        public IHttpActionResult PostReview(Review review)
        {
            var serviceTypeObj = db.ServiceTypes.FirstOrDefault(x => x.ServiceTypeCd == review.ServiceTypeCd);
            var reviewType = db.ReviewRatingTypes.FirstOrDefault(x => x.ReviewRatingTypeCd == review.ReviewRatingTypeCd);
            var user = db.ReviewUsers.FirstOrDefault(x => x.UserId == review.UserId);

            if (serviceTypeObj == null || reviewType == null || user == null)
                return BadRequest("One of the arguments is not valid");

            review.User = user;
            review.ServiceType = serviceTypeObj;
            review.ReviewRatingType = reviewType;
            review.Comments = review.Comments;
            review.UserId = user.UserId;
            review.ReviewRatingTypeCd = reviewType.ReviewRatingTypeCd;
            review.ServiceTypeCd = serviceTypeObj.ServiceTypeCd;

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
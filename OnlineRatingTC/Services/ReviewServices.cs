using System.Collections.Generic;
using System.Linq;
using OnlineRatingTC.Models;

namespace OnlineRatingTC.Services
{
    public class ReviewServices
    {
        private readonly ApplicationDbContext db;

        public ReviewServices(ApplicationDbContext _db)
        {
            db = _db;
        }

        public IEnumerable<Review> GetListOfReviews()
        {
            return db.Reviews.ToList();
        }

        public Review GetReview(int id)
        {
            return db.Reviews.Find(id);
        }

        public void CreateReview(Review review)
        {
            db.Reviews.Add(review);
            db.SaveChanges();
        }


    }
}
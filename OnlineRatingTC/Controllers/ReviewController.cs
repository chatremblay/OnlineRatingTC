using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineRatingTC.Models;
using OnlineRatingTC.Services;
using OnlineRatingTC.ViewModels;

namespace OnlineRatingTC.Controllers
{
    public class ReviewController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Review
        public ActionResult Index()
        {
            return View(GetReviewViewModel(-1));
        }

        // GET: Review/Details/5
        public ActionResult Details(int id)
        {
            var reviewViewModel = GetReviewViewModel(id);
            return View(reviewViewModel);
        }

        private ReviewViewModel GetReviewViewModel(int id)
        {
            var reviewService = new ReviewServices(db);
            var reviewViewModel = new ReviewViewModel();
            reviewViewModel.Reviews = reviewService.GetListOfReviews();

            if (id != -1)
                reviewViewModel.Review = reviewService.GetReview(id);

            var query = db.ReviewUsers.Select(x => new
            {
                userId = x.UserId,
                userName = x.Name
            }).OrderBy(x => x.userName);

            reviewViewModel.UsersList = query.Any() ?
                query.ToDictionary(key => key.userId, value => value.userName).ToList() : new Dictionary<int, string>().ToList();

            var query1 = db.ReviewRatingTypes.Select(x => new
            {
                reviewRatingId = x.ReviewRatingTypeCd,
                reviewName = x.ReviewRatingTypeName
            }).OrderBy(x => x.reviewName);

            reviewViewModel.ReviewRatingList = query1.Any() ?
                query1.ToDictionary(key => key.reviewRatingId, value => value.reviewName).ToList() : new Dictionary<int, string>().ToList();

            var query2 = db.ServiceTypes.Select(x => new
            {
                serviceId = x.ServiceTypeCd,
                serviceName = x.ServiceTypeName
            }).OrderBy(x => x.serviceName);

            reviewViewModel.ServicesList = query2.Any() ?
                query2.ToDictionary(key => key.serviceId, value => value.serviceName).ToList() : new Dictionary<int, string>().ToList();
            return reviewViewModel;
        }

        // GET: Review/Create
        public ActionResult Create()
        {
            return View(GetReviewViewModel(-1));
        }

        // POST: Review/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

       

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

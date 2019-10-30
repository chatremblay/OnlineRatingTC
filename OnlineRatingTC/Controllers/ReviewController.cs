using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
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
            ApplicationUser user = 
                System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>()
                    .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            var userService = new UsersServices(db);
            var userInfo = userService.GetUserByEmail(user.Email);

            var reviewViewModel = GetReviewViewModel(userInfo.UserId);

            reviewViewModel.LogUser = userInfo;
            reviewViewModel.Note = "";
            return View(reviewViewModel);
           
        }

        // POST: Review/Create
        [HttpPost]
        public ActionResult Create(ReviewViewModel modelView)
        {
            try
            {

                
                ApplicationUser user =
                    System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>()
                        .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
                var userService = new UsersServices(db);
                var userInfo = userService.GetUserByEmail(user.Email);

                if (modelView.Note.IsEmpty())
                {
                    ModelState.AddModelError(string.Empty, "Comments cannot be empty");
                    var reviewInfoModel = GetReviewViewModel(userInfo.UserId);
                    reviewInfoModel.LogUser = userInfo;
                    return View("Create", reviewInfoModel);
                }

                var reviewService = new ReviewServices(db);
                var review = new Review();

                review.Comments = modelView.Note;
                review.ReviewRatingTypeCd = modelView.ReviewRatingCd;
                review.ServiceTypeCd = modelView.SystemCd;
                review.UserId = userInfo.UserId;


                var serviceType = db.ServiceTypes.FirstOrDefault(x => x.ServiceTypeCd == modelView.SystemCd);
                review.ServiceType = serviceType;
                var reviewType =
                    db.ReviewRatingTypes.FirstOrDefault(x => x.ReviewRatingTypeCd == modelView.ReviewRatingCd);
                review.ReviewRatingType = reviewType;

               // review.
                reviewService.CreateReview(review);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
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

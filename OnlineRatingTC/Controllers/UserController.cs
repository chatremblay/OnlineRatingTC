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
    public class UserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //// GET: User
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: User/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: User/Create
        public ActionResult Create(string email)
        {
            var userModel = new UsersViewModel();
            userModel.Email = email;
            return View(userModel);
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UsersViewModel newUser)
        {
            try
            {
                var userService = new UsersServices(db);
                var user = new User();
                user.Email = newUser.Email;
                user.Name = newUser.Name;
                user.City = newUser.City;

                userService.CreateUser(user);
                return RedirectToAction("Index", "Review");
            }
            catch
            {
                return View();
            }
        }

        //// GET: User/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: User/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

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

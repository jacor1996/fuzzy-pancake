using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Abstract;
using DAL.DataModel;

namespace WebApplication.Controllers
{
    [Authorize]
    public class UserActivityController : Controller
    {
        private IDataRepository repository;

        public UserActivityController(IDataRepository repository)
        {
            this.repository = repository;
        }

        // GET: UserActivity
        public ActionResult Index(string date)
        {
            //DateTime dt = DateTime.Parse(date);
            var userActivity = repository.GetUserActivities();
            return View(userActivity);
        }

        public ActionResult AddActivity(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public ActionResult AddActivity(int id, UserActivity userActivity)
        {
            userActivity.ActivityId = id;
            userActivity.Activity = repository.FindActivity(id);
            
            string userName = HttpContext.User.Identity.Name;
            if (IsValidUser(userName))
            {
                userActivity.User = repository.FindUser(userName);
                userActivity.UserId = userActivity.User.UserId;
            }

            ModelState.Remove("ActivityId");
            if (ModelState.IsValid)
            {
                repository.SaveUserActivity(userActivity);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            UserActivity userActivity = repository.FindUserActivity(id);
            if (userActivity == null)
            {
                return HttpNotFound("UserActivity does not exist.");
            }
            return View(userActivity);
        }

        [HttpPost]
        public ActionResult Edit(UserActivity userActivity, int id)
        {

            userActivity.ActivityId = id;
            userActivity.Activity = repository.FindActivity(id);

            string userName = HttpContext.User.Identity.Name;
            if (IsValidUser(userName))
            {
                userActivity.User = repository.FindUser(userName);
                userActivity.UserId = userActivity.User.UserId;
            }

            ModelState.Remove("ActivityId");
            if (ModelState.IsValid)
            {
                repository.SaveUserActivity(userActivity);
            }

            return RedirectToAction("Index");
        }

        public bool IsValidUser(string userName)
        {
            User user = repository.FindUser(userName);
            string loggedUser = HttpContext.User.Identity.Name;
            string nameToCompare = user.Name.Substring(0, loggedUser.Length);

            return nameToCompare.Equals(loggedUser);
        }
    }
}
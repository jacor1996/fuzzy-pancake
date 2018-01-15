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
    public class ActivityController : Controller
    {
        private IDataRepository repository;

        public ActivityController(IDataRepository repository)
        {
            this.repository = repository;
        }

        // GET: Activity
        public ActionResult Index()
        {
            var activities = repository.GetActivities();
            return View(activities);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Activity activity)
        {
            if (ModelState.IsValid)
            {
                repository.SaveActivity(activity);
                return RedirectToAction("Index");
            }
            return View(activity);
        }

        public ActionResult Edit(int id)
        {
            var activity = repository.FindActivity(id);

            if (activity == null)
            {
                return HttpNotFound("Id does not exist");
            }

            return View(activity);
        }

        [HttpPost]
        public ActionResult Edit(Activity activity)
        {
            if (ModelState.IsValid)
            {
                repository.SaveActivity(activity);
                return RedirectToAction("Index");
            }

            return View(activity);
        }

        public ActionResult Get(string activityName)
        {
            IEnumerable<Activity> data;
            if (activityName != String.Empty)
            {
                data = repository.GetActivities(activityName);
            }

            else
            {
                data = repository.GetActivities().Take(5);
            }

            return View(data);
        }
    }
}
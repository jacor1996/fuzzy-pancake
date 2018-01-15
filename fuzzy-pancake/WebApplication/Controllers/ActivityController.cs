using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Abstract;

namespace WebApplication.Controllers
{
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
    }
}
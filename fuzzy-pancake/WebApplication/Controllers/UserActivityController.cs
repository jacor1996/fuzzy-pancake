using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Abstract;
using DAL.DataModel;

namespace WebApplication.Controllers
{
    public class UserActivityController : Controller
    {
        private IDataRepository repository;

        public UserActivityController(IDataRepository repository)
        {
            this.repository = repository;
        }

        // GET: UserActivity
        public ActionResult Index()
        {
            var userActivity = repository.GetUserActivities();
            return View(userActivity);
        }
    }
}
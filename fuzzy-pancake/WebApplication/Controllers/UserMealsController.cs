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
    public class UserMealsController : Controller
    {
        private IDataRepository repository;

        public UserMealsController(IDataRepository repository)
        {
            this.repository = repository;
        }

        // GET: UserMeals
        public ActionResult Index()
        {
            string userName = HttpContext.User.Identity.Name;
            var userMeals = repository.GetUserMeals(userName);
            return View(userMeals);
        }
    }
}
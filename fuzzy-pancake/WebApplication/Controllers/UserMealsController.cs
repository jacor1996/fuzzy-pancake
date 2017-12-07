using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Abstract;

namespace WebApplication.Controllers
{
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
            return View();
        }
    }
}
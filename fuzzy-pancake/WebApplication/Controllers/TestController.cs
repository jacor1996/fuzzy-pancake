using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Abstract;
using DAL.DataModel;

namespace WebApplication.Controllers
{
    public class TestController : Controller
    {
        private IDataRepository repo;

        public TestController(IDataRepository repository)
        {
            this.repo = repository;
        }

        // GET: Test
        public ActionResult Index()
        {
            return View(repo.GetMeals());
        }

        public ActionResult Details(int id)
        {
            Meal meal = repo.FindMeal(id);
            return View(meal);
        }
    }
}
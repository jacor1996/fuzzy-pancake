using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DAL.Abstract;
using DAL.DataModel;

namespace WebApplication.Controllers
{
    public class MealController : Controller
    {
        private IDataRepository _repository;

        public MealController(IDataRepository repository)
        {
            this._repository = repository;
        }

        // GET: Meal
        public ActionResult Index()
        {
            var data = _repository.GetMeals();

            ViewBag.User = HttpContext.User.Identity.Name;

            return View(data);
        }

        public ActionResult Get(string mealName)
        {
            IEnumerable<Meal> data;
            if (mealName != String.Empty)
            {
                data = _repository.GetMeals(mealName);
            }

            else
            {
                data = _repository.GetMeals().Take(5);
            }

            return View(data);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(Meal meal)
        {
            if (ModelState.IsValid)
            {
                _repository.SaveMeal(meal);
                return RedirectToAction("Index");
            }
            return View(meal);
        }

        public ActionResult Details(int id)
        {
            Meal meal = _repository.FindMeal(id);
          
            if (meal == null)
            {
                //Add message that specified meal doesn't exist or redirect to index
                return HttpNotFound();
            }

            return View(meal);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            Meal meal = _repository.FindMeal(id);
            return View(meal);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(Meal meal)
        {
            if (ModelState.IsValid)
            {
                _repository.SaveMeal(meal);
                return RedirectToAction("Index");
            }

            return View(meal);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            _repository.RemoveMeal(id);
            return RedirectToAction("Index");
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Abstract;
using DAL.DataModel;

namespace WebApplication.Controllers
{
    public class MealController : Controller
    {
        private IDataRepository repository;

        public MealController(IDataRepository repository)
        {
            this.repository = repository;
        }

        // GET: Meal
        public ActionResult Index()
        {
            var data = repository.GetMeals();
            
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Meal meal)
        {
            if (ModelState.IsValid)
            {
                repository.SaveMeal(meal);
                return RedirectToAction("Index");
            }
            return View(meal);
        }

        public ActionResult Details(int id)
        {
            Meal meal = repository.FindMeal(id);
          
            if (meal == null)
            {
                //Add message that specified meal doesn't exist or redirect to index
                return HttpNotFound();
            }

            return View(meal);
        }

        public ActionResult Edit(int id)
        {
            Meal meal = repository.FindMeal(id);
            return View(meal);
        }

        [HttpPost]
        public ActionResult Edit(Meal meal)
        {
            if (ModelState.IsValid)
            {
                repository.SaveMeal(meal);
                return RedirectToAction("Index");
            }

            return View(meal);
        }

        public ActionResult Delete(int id)
        {
            repository.RemoveMeal(id);
            return RedirectToAction("Index");
        }

    }
}
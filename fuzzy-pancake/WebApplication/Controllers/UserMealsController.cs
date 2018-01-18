using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Abstract;
using DAL.DataModel;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Authorize]
    public class UserMealsController : Controller
    {
        private IDataRepository repository;
        private UserMealsViewModel model;

        public UserMealsController(IDataRepository repository)
        {
            this.repository = repository;
            this.model = new UserMealsViewModel();
        }

        public ActionResult Index(string date)
        {
            string userName = HttpContext.User.Identity.Name;
            model.User = repository.FindUser(userName);
            var data = repository.GetUserMeals(userName);

            if (String.IsNullOrEmpty(date))
            {
                model.Date = DateTime.Now;
                date = model.Date.ToShortDateString();
                model.UserMeals = data.ToList();
                model.Activities = repository.GetUserActivities();
            }
            else
            {
                model.Date = DateTime.Parse(date);
            }

           
            DateTime dt = DateTime.Parse(date);
            model.UserMeals = data.Where(x => x.Date == dt).ToList();
            model.Activities = repository.GetUserActivities().Where(x => x.Date == dt && x.User.Name == model.User.Name);


            model.CaloryHelper = new CaloryHelper(model.UserMeals.ToList(), repository.FindUser(userName), model.Activities.ToList());

            var breakfast = model.UserMeals.Where(x => x.MealNumber == 0);
            var lunch = model.UserMeals.Where(x => x.MealNumber == 1);
            var dinner = model.UserMeals.Where(x => x.MealNumber == 2);
            var snack = model.UserMeals.Where(x => x.MealNumber == 3);
            var supper = model.UserMeals.Where(x => x.MealNumber == 4);

            model.SetMeals(breakfast, lunch, dinner, snack, supper);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var userMeal = repository.FindUserMeals(id);
            if (userMeal == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.MealNames = CreateDropDownForMealNames();

            return View(userMeal);
        }

        [HttpPost]
        public ActionResult Edit(int id, int MealNames, User_Meals userMeal)
        {
            userMeal.MealId = id;
            userMeal.Meal = repository.FindMeal(id);
            userMeal.MealNumber = MealNames;
            string user = HttpContext.User.Identity.Name;
            if (IsValidUser(user))
            {
                userMeal.User = repository.FindUser(user);
                userMeal.UserId = userMeal.User.UserId;
            }

            ModelState.Remove("MealId");
            if (ModelState.IsValid)
            {
                repository.SaveUserMeal(userMeal);
            }
            return RedirectToAction("Index");
        }

        public ActionResult AddMeal(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.MealNames = CreateDropDownForMealNames(); 

            return View();
        }

        [HttpPost]
        public ActionResult AddMeal(int id, int MealNames, User_Meals userMeal)
        {
            userMeal.MealId = id;
            userMeal.Meal = repository.FindMeal(id);
            userMeal.MealNumber = MealNames;
            string user = HttpContext.User.Identity.Name;
            if (IsValidUser(user))
            {
                userMeal.User = repository.FindUser(user);
                userMeal.UserId = userMeal.User.UserId;
            }

            ModelState.Remove("MealId");
            if (ModelState.IsValid)
            {
                repository.SaveUserMeal(userMeal);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            User_Meals userMeals = repository.FindUserMeals(id);
            if (userMeals != null)
            {
                repository.RemoveUserMeal(id);
            }
            return RedirectToAction("Index");
        }

        public static List<SelectListItem> CreateDropDownForMealNames()
        {
            List<SelectListItem> mealNames = new List<SelectListItem>();
            mealNames.Add(new SelectListItem { Value = "0", Text = "Breakfast"});
            mealNames.Add(new SelectListItem { Value = "1", Text = "Lunch" });
            mealNames.Add(new SelectListItem { Value = "2", Text = "Dinner" });
            mealNames.Add(new SelectListItem { Value = "3", Text = "Snack" });
            mealNames.Add(new SelectListItem { Value = "4", Text = "Supper" });

            return mealNames;
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
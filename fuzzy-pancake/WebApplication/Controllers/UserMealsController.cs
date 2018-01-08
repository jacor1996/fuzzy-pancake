using System;
using System.Collections.Generic;
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
            this.model.Date = System.DateTime.Now;
        }

        // GET: UserMeals
        public ActionResult Index()
        {
            string userName = HttpContext.User.Identity.Name;
            var userMeals = repository.GetUserMeals(userName);

            return View(userMeals);
        }

        public ActionResult Index2(string date)
        {
            string userName = HttpContext.User.Identity.Name;
            //string date = "12/14/2017";

            var data = repository.GetUserMeals(userName);
            if (date == null)
            {
                model.UserMeals = data.ToList();
            }
            else
            {
                DateTime dt = DateTime.Parse(date.ToString());
                //model.UserMeals = data.Where(x => x.Date.ToString().Contains(date)).ToList();
                model.UserMeals = data.Where(x => x.Date == dt).ToList();
            }
            
            return View(model);
        }

        /*
        public ActionResult GetUserMeals(string date)
        {
            string userName = HttpContext.User.Identity.Name;
            var userMeals = repository.GetUserMeals(userName, date);

            return View(userMeals);
        }
        */
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
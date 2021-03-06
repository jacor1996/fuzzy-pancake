﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DAL.Abstract;
using DAL.DataModel;

namespace DAL.Concrete
{
    public class DataRepository : IDataRepository
    {
        //private DataModel.DataModel _db = new DataModel.DataModel();
        private FinalModel _db = new FinalModel();

        public IQueryable<Meal> GetMeals()
        {
            return _db.Meals;
        }

        public Meal FindMeal(int id)
        {
            //Can be null, check in controller
            Meal meal = _db.Meals.FirstOrDefault(x => x.MealId == id);
            return meal;
        }

        public IQueryable<Meal> GetMeals(string mealName)
        {
            return _db.Meals.Where(x => x.Name.Contains(mealName));
        }

        public void SaveMeal(Meal meal)
        {
            if (meal.MealId == 0)
            {
                _db.Meals.Add(meal);
            }
            else
            {
                Meal dbEntry = _db.Meals.Find(meal.MealId);
                if (dbEntry != null)
                {
                    dbEntry.Name = meal.Name;
                    dbEntry.Calories = meal.Calories;
                    dbEntry.Carbohydrates = meal.Carbohydrates;
                    dbEntry.Fats = meal.Fats;
                    dbEntry.Protein = meal.Protein;
                }
            }
            _db.SaveChanges();

        }

        public void RemoveMeal(int id)
        {
            Meal meal = _db.Meals.Find(id);

            if (meal != null)
            {
                _db.Meals.Remove(meal);
                _db.SaveChanges();
            }
        }

        public IQueryable<User> GetUsers()
        {
            return _db.Users;
        }

        public void SaveUser(User user)
        {
            User dbEntry = _db.Users.Find(user.UserId);

            if (dbEntry == null) //create new entry
            {
                _db.Users.Add(user);
            }

            else //edit dbEntry
            {
                dbEntry.Age = user.Age;
                dbEntry.Height = user.Height;
                dbEntry.Weight = user.Weight;
            }

            _db.SaveChanges();
        }

        public void RemoveUser(int id)
        {
            throw new NotImplementedException();
        }

        public User FindUser(string userName)
        {
            User user = _db.Users.FirstOrDefault(x => x.Name.Equals(userName));
            return user;
        }

        public User FindUser(int id)
        {
            User user = _db.Users.FirstOrDefault(x => x.UserId == id);
            return user;
        }

        public double GetDailyCalories(int id)
        {
            User user = FindUser(id);
            return ( (9.99 * user.Weight) + (6.25 * user.Height - 4.92 * user.Age) + 5 );
        }

        public IQueryable<User_Meals> GetUserMeals(string userName)
        {
            return _db.User_Meals.Where(x => x.User.Name.Equals(userName))
                .Include(meal => meal.Meal)
                .Include(user => user.User);
        }

        public IQueryable<User_Meals> GetUserMeals(string userName, DateTime date)
        {
            string s = date.ToShortDateString();
            return _db.User_Meals.Where(x => x.User.Name.Equals(userName) && x.Date == date)
                .Include(meal => meal.Meal)
                .Include(user => user.User);
        }

        public User_Meals FindUserMeals(int id)
        {
            User_Meals userMeals = _db.User_Meals.FirstOrDefault(x => x.UserMealId == id);
            return userMeals;
        }

        public void SaveUserMeal(User_Meals userMeal)
        {
            User_Meals dbEntry = _db.User_Meals.Find(userMeal.UserMealId);

            if (dbEntry == null) //create new entry
            {
                _db.User_Meals.Add(userMeal);
            }

            else //edit dbEntry
            {
                //dbEntry.User = userMeal.User;
                //dbEntry.Meal = userMeal.Meal;
                //dbEntry.MealId = userMeal.MealId;
                dbEntry.MealNumber = userMeal.MealNumber;
                //dbEntry.UserId = userMeal.UserId;
                //dbEntry.UserMealId = userMeal.UserMealId;
                dbEntry.Amount = userMeal.Amount;
                dbEntry.Date = userMeal.Date;
            }

            _db.SaveChanges();
        }

        public void RemoveUserMeal(int id)
        {
            User_Meals userMealsToDelete = FindUserMeals(id);
            _db.User_Meals.Remove(userMealsToDelete);
            _db.SaveChanges();
        }

        //Activities
        public IQueryable<Activity> GetActivities()
        {
            return _db.Activities;
        }

        public IQueryable<Activity> GetActivities(string activityName)
        {
            return GetActivities().Where(x => x.Name.Contains(activityName));
        }

        public Activity FindActivity(int id)
        {
            return _db.Activities.FirstOrDefault(x => x.ActivityId == id);
        }

        public void SaveActivity(Activity activity)
        {
            Activity dbEntry = _db.Activities.Find(activity.ActivityId);

            if (dbEntry == null) //create new entry
            {
                _db.Activities.Add(activity);
            }

            else //edit dbEntry
            {
                dbEntry.ActivityId = activity.ActivityId;
                dbEntry.CaloriesBurnedPerHour = activity.CaloriesBurnedPerHour;
                dbEntry.Name = activity.Name;
            }

            _db.SaveChanges();
        }

        //UserActivities
        public IQueryable<UserActivity> GetUserActivities()
        {
            return _db.UserActivities
                .Include(x => x.User)
                .Include(x => x.Activity);
        }

        public UserActivity FindUserActivity(int id)
        {
            var userActivity = _db.UserActivities.FirstOrDefault(x => x.UserActivityId == id);
            return userActivity;
        }

        public void SaveUserActivity(UserActivity userActivity)
        {
            UserActivity dbEntry = _db.UserActivities.Find(userActivity.ActivityId);

            if (dbEntry == null) //create new entry
            {
                _db.UserActivities.Add(userActivity);
            }

            else //edit dbEntry
            {
                //dbEntry.UserId = userActivity.UserId;
                //dbEntry.User = userActivity.User;
                //dbEntry.Activity = userActivity.Activity;
                //dbEntry.ActivityId = userActivity.ActivityId;
                //dbEntry.UserActivityId = userActivity.UserActivityId;
                dbEntry.Date = userActivity.Date;
                dbEntry.Hours = userActivity.Hours;
                dbEntry.Minutes = userActivity.Minutes;
                dbEntry.Seconds = userActivity.Seconds;
                
            }

            _db.SaveChanges();
        }

        public void RemoveUserActivity(int id)
        {
            UserActivity activityToRemove = FindUserActivity(id);
            _db.UserActivities.Remove(activityToRemove);
            _db.SaveChanges();
        }
    }
}

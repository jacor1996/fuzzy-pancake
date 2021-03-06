﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataModel;

namespace DAL.Abstract
{
    public interface IDataRepository
    {
        //Meals
        IQueryable<Meal> GetMeals();

        IQueryable<Meal> GetMeals(string mealName);

        void SaveMeal(Meal meal);

        void RemoveMeal(int id);

        Meal FindMeal(int id);

        //Users
        IQueryable<User> GetUsers();
    
        void SaveUser(User user);

        void RemoveUser(int id);

        User FindUser(string userName);

        User FindUser(int id);

        double GetDailyCalories(int id);

        //UserMeals
        IQueryable<User_Meals> GetUserMeals(string userName);

        IQueryable<User_Meals> GetUserMeals(string userName, DateTime date);

        User_Meals FindUserMeals(int id);

        void SaveUserMeal(User_Meals userMeal);

        void RemoveUserMeal(int id);

        //Activities
        IQueryable<Activity> GetActivities();

        IQueryable<Activity> GetActivities(string activityName);

        void SaveActivity(Activity activity);

        Activity FindActivity(int id);

        //UserActivities
        IQueryable<UserActivity> GetUserActivities();

        void SaveUserActivity(UserActivity userActivity);

        UserActivity FindUserActivity(int id);

        void RemoveUserActivity(int id);

    }
}

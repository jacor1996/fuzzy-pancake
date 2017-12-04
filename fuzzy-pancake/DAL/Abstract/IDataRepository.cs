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

        void SaveMeal(Meal meal);

        void RemoveMeal(int id);

        Meal FindMeal(int id);

        //Users
        IQueryable<User> GetUsers();
    
        void SaveUser(User user);

        void RemoveUser(int id);

        User FindUser(string userName);
    }
}

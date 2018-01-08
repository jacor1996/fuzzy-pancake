using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.DataModel;

namespace WebApplication.Models
{
    public class CaloryHelper
    {
        private IQueryable<User_Meals> Meals { get; set; }
        public double Fats { get; set; } = 0;
        public double Carbohydrates { get; set; } = 0;
        public double Proteins { get; set; } = 0;
        public double Calories { get; set; } = 0;

        public CaloryHelper(IQueryable<User_Meals> data)
        {
            Meals = data;
            ComputeDailyNutrients();
        }

        private void ComputeDailyNutrients()
        {
            foreach (User_Meals u in Meals)
            {
                //Amount equals 0 by default
                Calories += (double)u.Amount * u.Meal.Calories;
                Fats += (double)u.Amount * u.Meal.Fats;
                Carbohydrates += (double)u.Amount * u.Meal.Carbohydrates;
                Proteins += (double) u.Amount * u.Meal.Protein;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.DataModel;

namespace WebApplication.Models
{
    public class CaloryHelper
    {
        private ICollection<User_Meals> Meals { get; set; }
        private User User { get; set; }
        public double Fats { get; set; } = 0;
        public double Carbohydrates { get; set; } = 0;
        public double Proteins { get; set; } = 0;
        public double Calories { get; set; } = 0;
        public double CaloriesLimit { get; set; } = 0;

        public CaloryHelper(ICollection<User_Meals> data, User user)
        {
            Meals = data;
            User = user;
            //ComputeDailyNutrients();
            CaloriesLimit = BMR();
        }

        private void ComputeDailyNutrients()
        {
            foreach (var u in Meals)
            {
                //Amount equals 0 by default
                Calories += (double)u.Amount * u.Meal.Calories;
                Fats += (double)u.Amount * u.Meal.Fats;
                Carbohydrates += (double)u.Amount * u.Meal.Carbohydrates;
                Proteins += (double) u.Amount * u.Meal.Protein;
            }
        }

        private double BMR()
        {
            const double weightConstant = 9.99;
            const double heightConstant = 4.92;
            const double ageConstant = 4.92;

            double bmr = weightConstant * User.Weight + heightConstant * User.Height - ageConstant * User.Age + 5;

            return bmr;
        }
    }
}
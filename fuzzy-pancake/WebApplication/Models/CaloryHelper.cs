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
        public double Bmi { get; set; } = 0;

        public double CaloriesFromFats;
        public double CaloriesFromCarbs;
        public double CaloriesFromProteins;
        public double FatsPercentage;
        public double ProteinsPercentage;
        public double CarbsPercentage;

        public CaloryHelper(ICollection<User_Meals> data, User user)
        {
            Meals = data;
            User = user;
            ComputeDailyNutrients();
            CaloriesLimit = ComputeBmr();
            Bmi = ComputeBmi();
        }

        private void ComputeDailyNutrients()
        {
            foreach (var u in Meals)
            {
                //Amount equals 0 by default
                Calories += ((double)u.Amount * u.Meal.Calories)/100;
                Fats += ((double)u.Amount * u.Meal.Fats)/100;
                Carbohydrates += ((double)u.Amount * u.Meal.Carbohydrates)/100;
                Proteins += ((double) u.Amount * u.Meal.Protein)/100;

            }

            CaloriesFromFats = Fats * 9;
            CaloriesFromCarbs = Carbohydrates * 4.5;
            CaloriesFromProteins = Proteins * 4.5;

            FatsPercentage = CaloriesFromFats / Calories * 100;
            CarbsPercentage = CaloriesFromCarbs / Calories * 100;
            ProteinsPercentage = CaloriesFromProteins / Calories * 100;
        }

        private double ComputeBmr()
        {
            const double weightConstant = 9.99;
            const double heightConstant = 4.92;
            const double ageConstant = 4.92;

            double bmr = weightConstant * User.Weight + heightConstant * User.Height - ageConstant * User.Age + 5;

            return bmr;
        }

        private double ComputeBmi()
        {
            double mass = User.Weight;
            double height = User.Height;
            double bmi = mass / (height * height);

            return bmi;
        }

    }
}
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
        private ICollection<UserActivity> Activities { get; set; }

        public double Fats { get; set; } = 0;
        public double Carbohydrates { get; set; } = 0;
        public double Proteins { get; set; } = 0;
        public double Calories { get; set; } = 0;
        public double CaloriesLimit { get; set; } = 0;
        public double Bmi { get; set; } = 0;
        public string BmiFeedback;

        public double CaloriesFromFats;
        public double CaloriesFromCarbs;
        public double CaloriesFromProteins;
        public double FatsPercentage;
        public double ProteinsPercentage;
        public double CarbsPercentage;

        public double CaloriesFromActivities;

        //Basic metabolic rate
        public double BMR;
        //Thermal efect of food = 10% of BMR
        public double TEF;
        //NEAT -> Additional calories depending from body type
        public double NEAT = 450;

        public CaloryHelper(ICollection<User_Meals> data, User user, ICollection<UserActivity> activities=null)
        {
            Meals = data;
            User = user;
            Activities = activities;
            ComputeDailyNutrients();
            BMR = ComputeBmr();
            TEF = ComputeTEF();
            CaloriesLimit = BMR + TEF + NEAT;
            Bmi = ComputeBmi();
            BmiFeedback = BmiMessage(Bmi);
            CaloriesFromActivities = ComputeCaloriesFromActivities();
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
            double height = User.Height /100; //Convert to meters
            double bmi = mass / (height * height);

            return bmi;
        }

        private string BmiMessage(double bmi)
        {
            string message = "";

            if (bmi < 18.5)
            {
                message = "Your BMI is too low";
            }

            if (bmi >= 18.5 && bmi < 25)
            {
                message = "You have normal BMI";
            }

            if (bmi > 25)
            {
                message = "Your BMI is too high";
            }

            return message;
        }

        private double ComputeCaloriesFromActivities()
        {
            double burnedCalories = 0;
            int s;
            int m;
            int h;

            foreach (UserActivity userActivity in Activities)
            {
                s = userActivity.Seconds;
                m = userActivity.Minutes;
                h = userActivity.Hours;

                burnedCalories += userActivity.Activity.CaloriesBurnedPerHour / 3600 * ConvertToSeconds(h, m, s);
            }

            return burnedCalories;
        }

        private int ConvertToSeconds(int h, int m, int s)
        {
            return s + (m * 60) + (h * 3600);
        }

        private double ComputeTEF()
        {
            double tef = BMR / 10;
            return tef;
        }
    }
}
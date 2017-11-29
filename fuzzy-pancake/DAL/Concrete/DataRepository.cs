using System;
using System.Collections.Generic;
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
        private DataModel.DataModel db = new DataModel.DataModel();

        public IQueryable<Meal> GetMeals()
        {
            return db.Meals;
        }

        public Meal FindMeal(int id)
        {
            //Can be null, check in controller
            Meal meal = db.Meals.FirstOrDefault(x => x.MealId == id);
            return meal;
        }

        public void SaveMeal(Meal meal)
        {
            if (meal.MealId == 0)
            {
                db.Meals.Add(meal);
            }
            else
            {
                Meal dbEntry = db.Meals.Find(meal.MealId);
                if (dbEntry != null)
                {
                    dbEntry.Name = meal.Name;
                    dbEntry.Calories = meal.Calories;
                    dbEntry.Carbohydrates = meal.Carbohydrates;
                    dbEntry.Fats = meal.Fats;
                    dbEntry.Protein = meal.Protein;
                }
            }
            db.SaveChanges();

        }

        public void RemoveMeal(int id)
        {
            Meal meal = db.Meals.Find(id);

            if (meal != null)
            {
                db.Meals.Remove(meal);
                db.SaveChanges();
            }
        }

    }
}

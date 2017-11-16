using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool AddMeal(Meal meal)
        {
            bool isSuccessful = false;
            if (!db.Meals.Contains(meal))
            {
                db.Meals.Add(meal);
                db.SaveChanges();
                isSuccessful = true;
            }
            return isSuccessful;
        }

    }
}

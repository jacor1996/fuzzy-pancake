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
        private DataModel.DataModel _db = new DataModel.DataModel();

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
    }
}

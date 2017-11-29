using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataModel;

namespace DAL.Abstract
{
    public interface IDataRepository
    {
        IQueryable<Meal> GetMeals();
        void SaveMeal(Meal meal);
        void RemoveMeal(int id);
        Meal FindMeal(int id);
    }
}

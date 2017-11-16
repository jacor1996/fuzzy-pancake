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
        bool AddMeal(Meal meal);
        Meal FindMeal(int id);
    }
}

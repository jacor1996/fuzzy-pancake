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
    }
}

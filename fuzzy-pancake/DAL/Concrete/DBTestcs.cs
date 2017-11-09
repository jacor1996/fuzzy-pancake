using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataModel;

namespace DAL.Concrete
{
    public static class DBTestcs
    {

        static void Main()
        {
            DataModel.DataModel data = new DataModel.DataModel();
            foreach(Meal m in data.Meals)
            {
                string s = $"{m.Name}, {m.Calories}, {m.MealId}";
                Console.WriteLine(s);
            }
        }
    }
}

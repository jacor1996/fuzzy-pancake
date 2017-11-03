using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    class DbConnectionTest
    {
        static void Main()
        {
            var db = new DataRepository();
            foreach (var entry in db.GetMeals())
            {
                Console.WriteLine(entry);
            }
        }
    }
}

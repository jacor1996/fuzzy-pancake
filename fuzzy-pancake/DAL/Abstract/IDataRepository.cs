using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface IDataRepository
    {
        IQueryable GetMeals();
        IQueryable GetUsers();
        //Get UserMeals for selected day
        IQueryable GetUserMeals();
    }
}

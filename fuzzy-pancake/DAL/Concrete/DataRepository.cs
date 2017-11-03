using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DbData;

namespace DAL.Concrete
{
    class DataRepository : IDataRepository
    {
        private readonly DataContext _dbContext;

        public DataRepository()
        {
            _dbContext = new DataContext();
        }

        public IQueryable GetMeals()
        {
            return _dbContext.Meals.AsQueryable();
        }

        public IQueryable GetUserMeals()
        {
            
            throw new NotImplementedException();
        }

        public IQueryable GetUsers()
        {
            return _dbContext.Users.AsQueryable();
        }
    }
}

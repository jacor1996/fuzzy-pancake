using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class UserMealsViewModel
    {
        public virtual ICollection<DAL.DataModel.User_Meals> UserMeals { get; set; }
        [DataType(DataType.Date)]
        public virtual DateTime Date { get; set; }
    }
}
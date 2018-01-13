using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DAL.DataModel;

namespace WebApplication.Models
{
    public class UserMealsViewModel
    {
        public virtual ICollection<DAL.DataModel.User_Meals> UserMeals { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public virtual DateTime Date { get; set; }

        public virtual User User { get; set; }
        public virtual CaloryHelper CaloryHelper { get; set; }
        
        public virtual IEnumerable<User_Meals> Breakfast { get; set; }
        public virtual IEnumerable<User_Meals> Lunch { get; set; }
        public virtual IEnumerable<User_Meals> Dinner { get; set; }
        public virtual IEnumerable<User_Meals> Snack { get; set; }
        public virtual IEnumerable<User_Meals> Supper { get; set; }

        public void SetMeals(IEnumerable<User_Meals> breakfast,
            IEnumerable<User_Meals> lunch,
            IEnumerable<User_Meals> dinner,
            IEnumerable<User_Meals> snack,
            IEnumerable<User_Meals> supper)
        {
            Breakfast = breakfast;
            Lunch = lunch;
            Dinner = dinner;
            Snack = snack;
            Supper = supper;
        }
    }
}
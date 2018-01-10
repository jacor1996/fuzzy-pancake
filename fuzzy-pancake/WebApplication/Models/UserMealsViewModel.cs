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
    }
}
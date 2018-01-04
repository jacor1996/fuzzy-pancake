using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.DataModel
{
    public partial class User_Meals
    {
        [Key]
        public int UserMealId { get; set; }

        [Range(0,5)]
        public int MealNumber { get; set; }

        public int? UserId { get; set; }

        public int? MealId { get; set; }

        public double? Amount { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        public virtual Meal Meal { get; set; }

        public virtual User User { get; set; }
    }
}

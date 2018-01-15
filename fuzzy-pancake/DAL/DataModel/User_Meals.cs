namespace DAL.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User_Meals
    {
        [Key]
        public int UserMealId { get; set; }

        public int MealNumber { get; set; }

        public int? UserId { get; set; }

        public int? MealId { get; set; }

        [Required(ErrorMessage = "Amount of food in grams.")]
        public double? Amount { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        public virtual Meal Meal { get; set; }

        public virtual User User { get; set; }
    }
}

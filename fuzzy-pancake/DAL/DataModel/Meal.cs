using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.DataModel
{
    public partial class Meal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Meal()
        {
            User_Meals = new HashSet<User_Meals>();
        }

        public int MealId { get; set; }

        [Required(ErrorMessage = "Enter meal name.")]
        [StringLength(128)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter amount of calories per 100 grams of product.")]
        public double Calories { get; set; }

        [Required(ErrorMessage = "Enter amount of fats per 100 grams of product.")]
        public double Fats { get; set; }

        [Required(ErrorMessage = "Enter amount of carbohydrates per 100 grams of product.")]
        public double Carbohydrates { get; set; }

        [Required(ErrorMessage = "Enter amount of protein per 100 grams of product.")]
        public double Protein { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User_Meals> User_Meals { get; set; }
    }
}

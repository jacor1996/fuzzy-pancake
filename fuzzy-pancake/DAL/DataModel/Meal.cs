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

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public double Calories { get; set; }

        public double Fats { get; set; }

        public double Carbohydrates { get; set; }

        public double Protein { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User_Meals> User_Meals { get; set; }
    }
}

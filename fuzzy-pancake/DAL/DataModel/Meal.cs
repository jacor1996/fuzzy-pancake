namespace DAL.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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

        [Required(ErrorMessage = "Enter calories per 100 grams of product.")]
        [Range(0, 5000)]
        public double Calories { get; set; }

        [Required(ErrorMessage = "Enter fats per 100 grams of product.")]
        [Range(0, 500)]
        public double Fats { get; set; }

        [Required(ErrorMessage = "Enter carbohydrates per 100 grams of product.")]
        [Range(0, 500)]
        public double Carbohydrates { get; set; }

        [Required(ErrorMessage = "Enter proteins per 100 grams of product.")]
        [Range(0,500)]
        public double Protein { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User_Meals> User_Meals { get; set; }
    }
}

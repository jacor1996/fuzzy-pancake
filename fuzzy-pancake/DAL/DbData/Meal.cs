//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.DbData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Meal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Meal()
        {
            this.User_Meals = new HashSet<User_Meals>();
        }
    
        public int MealId { get; set; }
        public string Name { get; set; }
        public double Calories { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }
        public double Protein { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User_Meals> User_Meals { get; set; }
    }
}

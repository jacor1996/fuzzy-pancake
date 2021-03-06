namespace DAL.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            User_Meals = new HashSet<User_Meals>();
            UserActivities = new HashSet<UserActivity>();
        }

        public int UserId { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Specify your age.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Enter your weight in kilograms.")]
        [Range(1,250)]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Enter your height in centimeters.")]
        [Range(100,220)]
        public double Height { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User_Meals> User_Meals { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserActivity> UserActivities { get; set; }
    }
}

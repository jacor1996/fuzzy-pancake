using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.DataModel
{
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            User_Meals = new HashSet<User_Meals>();
        }

        public int UserId { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public int Age { get; set; }

        public double Weight { get; set; }

        public double Height { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User_Meals> User_Meals { get; set; }
    }
}

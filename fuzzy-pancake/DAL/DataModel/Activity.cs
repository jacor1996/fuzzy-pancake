namespace DAL.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Activity")]
    public partial class Activity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Activity()
        {
            UserActivities = new HashSet<UserActivity>();
        }

        public int ActivityId { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public double CaloriesBurnedPerHour { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserActivity> UserActivities { get; set; }
    }
}

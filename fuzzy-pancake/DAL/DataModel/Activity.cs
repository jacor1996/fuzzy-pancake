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
        public int ActivityId { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public double CaloriesBurnedPerHour { get; set; }
    }
}

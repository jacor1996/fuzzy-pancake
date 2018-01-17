namespace DAL.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserActivity")]
    public partial class UserActivity
    {
        public int UserActivityId { get; set; }

        public int UserId { get; set; }

        public int ActivityId { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Select date")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Values from 0 to 12")]
        [Range(0,12)]
        public int Hours { get; set; }
        [Required(ErrorMessage = "Values from 0 to 59")]
        [Range(0, 59)]
        public int Minutes { get; set; }
        [Required(ErrorMessage = "Values from 0 to 59")]
        [Range(0, 59)]
        public int Seconds { get; set; }

        public virtual Activity Activity { get; set; }

        public virtual User User { get; set; }
    }
}

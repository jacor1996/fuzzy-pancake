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
        public DateTime Date { get; set; }

        public TimeSpan Time { get; set; }

        public virtual Activity Activity { get; set; }

        public virtual User User { get; set; }
    }
}

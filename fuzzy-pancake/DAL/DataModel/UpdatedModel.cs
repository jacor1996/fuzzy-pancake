namespace DAL.DataModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class UpdatedModel : DbContext
    {
        public UpdatedModel()
            : base("name=UpdatedModel")
        {
        }

        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<Meal> Meals { get; set; }
        public virtual DbSet<User_Meals> User_Meals { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Meal>()
                .Property(e => e.Name)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}

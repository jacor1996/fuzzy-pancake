namespace DAL.DataModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FinalModel : DbContext
    {
        public FinalModel()
            : base("name=FinalModel")
        {
        }

        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<Meal> Meals { get; set; }
        public virtual DbSet<User_Meals> User_Meals { get; set; }
        public virtual DbSet<UserActivity> UserActivities { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Activity>()
                .HasMany(e => e.UserActivities)
                .WithRequired(e => e.Activity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Meal>()
                .Property(e => e.Name)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserActivities)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}

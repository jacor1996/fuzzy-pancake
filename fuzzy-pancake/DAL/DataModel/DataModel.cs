using System.Data.Entity;

namespace DAL.DataModel
{
    public partial class DataModel : DbContext
    {
        public DataModel()
            : base("name=DataModel")
        {
        }

        public virtual DbSet<Meal> Meals { get; set; }
        public virtual DbSet<UserMeals> UserMeals { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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

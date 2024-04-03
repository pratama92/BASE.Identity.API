using BASE.Identity.Repository.Model;
using Microsoft.EntityFrameworkCore;


namespace BASE.Identity.Repository.Repositories
{
    public partial class DataBaseContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-HOME-IN;Initial Catalog=BASE.Local;Persist Security Info=True;User ID=admin;Password=admin;Trust Server Certificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("User");

                entity.Property(e => e.Password).HasMaxLength(50);
                entity.Property(e => e.UserEmail).HasMaxLength(50);
                entity.Property(e => e.UserId).HasMaxLength(50);
                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}

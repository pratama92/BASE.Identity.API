using BASE.Identity.Repository.Models;
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
                entity.ToTable("TblUser");
                entity.HasKey(e => e.UserID);
                entity.Property(e => e.UserID).IsRequired();
                entity.Property(e => e.Password).HasMaxLength(50);
                entity.Property(e => e.Email).HasMaxLength(50);
                entity.Property(e => e.UserID).HasMaxLength(50);
                entity.Property(e => e.UserName).HasMaxLength(50);
                entity.Property(e => e.CreatedDate)
                     .IsRequired();
                entity.Property(e => e.ModifiedDate)
                      .IsRequired();
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("TblRole");
                entity.HasKey(e => e.RoleID);
                entity.Property(e => e.RoleID).HasColumnType("uniqueidentifier").IsRequired();
                entity.Property(e => e.RoleName)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.Property(e => e.RoleDescription)
                      .IsRequired(false);
                entity.Property(e => e.CreatedDate)
                      .IsRequired();                    
                entity.Property(e => e.ModifiedDate)
                      .IsRequired();
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}

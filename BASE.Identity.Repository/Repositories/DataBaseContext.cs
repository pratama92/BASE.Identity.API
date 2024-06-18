using BASE.Identity.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace BASE.Identity.Repository.Repositories
{
    public partial class DataBaseContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var appSetting = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var connString = appSetting.GetValue<string>("ConnectionStrings:string");

            optionsBuilder.UseSqlServer(connString);
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

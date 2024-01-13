using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace car_magazine
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("name=AppDbContext")
        {
        }

        public DbSet<Category> categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.name)
                .IsUnicode(false);


            modelBuilder.Entity<User>()
           .Property(e => e.Name)
           .HasMaxLength(50)
           .IsRequired();

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}

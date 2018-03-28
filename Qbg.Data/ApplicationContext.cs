using Microsoft.EntityFrameworkCore;
using Qbg.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Qbg.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public ApplicationContext()
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().Property(p => p.DateCreated).HasDefaultValue(DateTime.UtcNow);

            builder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.RoleId});

            builder.Entity<UserRole>().HasOne(ur => ur.User).WithMany(u => u.UserRoles).HasForeignKey(ur=>ur.UserId);
            builder.Entity<UserRole>().HasOne(ur => ur.Role).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.RoleId);

            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            UpdateUpdatedProperty<User>();

            return base.SaveChanges();
        }

        private void UpdateUpdatedProperty<T>() where T : class
        {
            //var modifiedSourceInfo =
            //    ChangeTracker.Entries<T>()
            //        .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            //foreach (var entry in modifiedSourceInfo)
            //{
            //    entry.Property("UpdatedTimestamp").CurrentValue = DateTime.UtcNow;
            //}
        }
    }
}

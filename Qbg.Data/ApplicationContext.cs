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
        public DbSet<QbgQueue> QbgQueues { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().Property(p => p.DateCreated).HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.RoleId});

            builder.Entity<UserRole>().HasOne(ur => ur.User).WithMany(u => u.UserRoles).HasForeignKey(ur=>ur.UserId);
            builder.Entity<UserRole>().HasOne(ur => ur.Role).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.RoleId);

            builder.Entity<QbgQueue>().Property(p => p.TimeStamp).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Entity<QbgQueueUser>().Property(p => p.TimeStamp).HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Entity<QbgQueueUser>().HasKey(ur => new { ur.UserId, ur.QbgQueueId});

            builder.Entity<QbgQueueUser>().HasOne(qq => qq.QbgQueue).WithMany(u => u.Queue).HasForeignKey(ur => ur.QbgQueueId);
            builder.Entity<QbgQueueUser>().HasOne(qq => qq.User).WithMany(u => u.QbgQueues).HasForeignKey(ur => ur.UserId);

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

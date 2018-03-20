using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NotificationService.Repository.Context.Configurations;
using NotificationService.Shared.Data;

namespace NotificationService.Repository.Context
{
    public class NotificationContext : DbContext, INotificationContext
    {
        public NotificationContext(DbContextOptions<NotificationContext> dbContextOptions)
        : base(dbContextOptions)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Notification");
            modelBuilder.ApplyConfiguration(new NotificationConfiguration());
            base.OnModelCreating(modelBuilder);
        }


        public virtual DbSet<Notification> Notifications { get; set; }
    }
}



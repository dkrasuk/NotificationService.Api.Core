using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NotificationService.Shared.Data;

namespace NotificationService.Repository.Context
{
    public interface INotificationContext : IDisposable
    {
        DbSet<Notification> Notifications { get; set; }
        DbSet<NotificationProtocol> NotificationProtocols { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}

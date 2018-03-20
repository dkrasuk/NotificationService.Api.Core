using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NotificationService.Repository.Context;
using NotificationService.Shared.Data;
using NotificationService.Shared.Repositories;

namespace NotificationService.Repository.Repositories
{
    public class NotificationRepository : INotificationRepository<Notification>
    {
        private readonly INotificationContext _dbContext;

        //public NotificationRepository() : this(() => new NotificationContext())
        //{

        //}

        public NotificationRepository(INotificationContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentException(nameof(dbContext));
        }

        public async Task CreateOrUpdateAsync(Notification notification)
        {
            using (var db = _dbContext)
            {

                if (notification.Id != Guid.Empty && db.Notifications.Any(n => n.Id == notification.Id))
                {
                    db.Notifications.Update(notification);
                }
                else
                {
                    db.Notifications.Add(notification);
                }

                await db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Notification>> GetAsync()
        {
            using (var db = _dbContext)
            {
                return await db.Notifications.ToArrayAsync();
            }
        }

        public async Task<Notification> GetAsync(Expression<Func<Notification, bool>> predicate)
        {
            using (var db = _dbContext)
            {
                return await db.Notifications.Where(predicate).FirstOrDefaultAsync();
            }
        }
    }
}

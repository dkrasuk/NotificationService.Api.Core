using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Shared.Repositories
{
    public interface INotificationRepository<T>
    {
        Task<IEnumerable<T>> GetAsync();
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task CreateOrUpdateAsync(T notification);
    }
}

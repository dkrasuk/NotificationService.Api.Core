using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationService.Api.Core.Services.Interfaces
{
    public interface INotificationService
    {
        Task<List<Shared.DTO.Notification>> GetAllAsync();
        Task<Shared.DTO.Notification> GetAsyncById(Guid id);
        Task CreateAsync(Shared.DTO.Notification notification);
    }
}

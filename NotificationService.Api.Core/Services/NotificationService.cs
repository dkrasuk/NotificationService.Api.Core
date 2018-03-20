using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using NotificationService.Shared.Data;
using NotificationService.Shared.Repositories;

namespace NotificationService.Api.Core.Services
{
    public class NotificationService
    {
        private readonly INotificationRepository<Notification> _notificationRepository;
        private readonly ILogger<NotificationService> _logger;
        private readonly IMapper _mapper;

        public NotificationService(INotificationRepository<Notification> notificationRepository,
            ILogger<NotificationService> logger,
            IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _logger = logger;
            _mapper = mapper;
        }


        public async Task<Shared.DTO.Notification[]> GetAllAsync()
        {
            var notifications = (await _notificationRepository.GetAsync()).ToArray();
            var notificationsDto = _mapper.Map<Shared.DTO.Notification[]>(notifications);
            return notificationsDto;
        }

        public async Task<Shared.DTO.Notification> GetAsyncById(Guid id)
        {
            var notification = (await _notificationRepository.GetAsync(n => n.Id == id));
            var notificationDto = _mapper.Map<Shared.DTO.Notification>(notification);
            return notificationDto;
        }

        public async Task CreateAsync(Shared.DTO.Notification notification)
        {
            if (notification == null)
            {
                _logger.LogError($"Notification has not been found. " +
                                 "So it's impossible to create notification of this type.");
                return;
            }
            var notificationData = _mapper.Map<Notification>(notification);
            await _notificationRepository.CreateOrUpdateAsync(notificationData);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using NotificationService.Api.Core.Services.Interfaces;
using NotificationService.Shared.Data;
using NotificationService.Shared.DTO;
using NotificationService.Shared.Repositories;
using Notification = NotificationService.Shared.Data.Notification;

namespace NotificationService.Api.Core.Services
{
    public class NotificationService : INotificationService
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


        public async Task<List<Shared.DTO.Notification>> GetAllAsync()
        {
            var notifications = (await _notificationRepository.GetAsync()).ToArray();
            var notificationsDto = new List<Shared.DTO.Notification>();

            foreach (var notification in notifications)
            {
                notificationsDto.Add(NotificationDataToDto(notification));
            }

            return notificationsDto;
        }

        public async Task<Shared.DTO.Notification> GetAsyncById(Guid id)
        {
            var notification = (await _notificationRepository.GetAsync(n => n.Id == id));
            if (notification == null)
                return null;

            var notificationDto = NotificationDataToDto(notification);
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

            var notificationData = NotificationDtoToData(notification);

            await _notificationRepository.CreateOrUpdateAsync(notificationData);
        }

        #region Private Methods
        private Notification NotificationDtoToData(Shared.DTO.Notification notificationDto)
        {
            var data = new Notification()
            {
                Id = notificationDto.Id,
                Protocol = new NotificationProtocol()
                {
                    Id = notificationDto.Protocol.Id,
                    Protocol = notificationDto.Protocol.Protocol
                },
                ModifyDate = notificationDto.ModifyDate,
                CreatedDate = notificationDto.CreatedDate,
                Body = notificationDto.Body,
                Channel = notificationDto.Channel,
                IsReaded = notificationDto.IsReaded,
                Receiver = notificationDto.Receiver,
                Title = notificationDto.Title,
                Type = notificationDto.Type
            };
            return data;
        }

        private Shared.DTO.Notification NotificationDataToDto(Notification notificationData)
        {
            var notificationDto = new Shared.DTO.Notification()
            {
                Protocol = new NotificationProtocolDto()
                {
                    Protocol = notificationData.Protocol.Protocol,
                    Id = notificationData.Protocol.Id
                },
                Id = notificationData.Id,
                ModifyDate = notificationData.ModifyDate,
                Title = notificationData.Title,
                Receiver = notificationData.Receiver,
                Channel = notificationData.Channel,
                Type = notificationData.Type,
                CreatedDate = notificationData.CreatedDate,
                Body = notificationData.Body,
                IsReaded = notificationData.IsReaded
            };
            return notificationDto;
        }
        #endregion

    }
}

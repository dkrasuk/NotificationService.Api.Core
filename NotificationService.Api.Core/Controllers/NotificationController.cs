﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotificationService.Api.Core.Services.Interfaces;
using NotificationService.Shared.DTO;

namespace NotificationService.Api.Core.Controllers
{
    [Route("api/[controller]")]
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _notificationService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _notificationService.GetAsyncById(id));
        }

        
        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] Notification notification)
        {
            await _notificationService.CreateAsync(notification);
            return Ok();
        }
    }
}

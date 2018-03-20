using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotificationService.Shared.DTO;

namespace NotificationService.Api.Core.Controllers
{
    [Route("api/[controller]")]
    public class NotificationController : Controller
    {
        private readonly Services.NotificationService _notificationService;

        public NotificationController(Services.NotificationService notificationService)
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

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

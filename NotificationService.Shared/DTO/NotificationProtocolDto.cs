using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace NotificationService.Shared.DTO
{
    public class NotificationProtocolDto
    {
        public int Id { get; set; }
        public string Protocol { get; set; }
     //   public ICollection<Notification> Notifications { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationService.Shared.Data
{
    public class NotificationProtocol
    {
        public int Id { get; set; }
        public string Protocol { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}

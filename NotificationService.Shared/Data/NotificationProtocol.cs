using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NotificationService.Shared.Data
{
    public class NotificationProtocol
    {
        [Key]
        public Guid uid_protocol { get; set; }
        public int Id { get; set; }
        public string Protocol { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using NotificationService.Shared.Data;

namespace NotificationService.Shared.DTO
{
    public class Notification
    {
        public Guid? Id { get; set; }

        public string Channel { get; set; }

        public string Receiver { get; set; }

        public string Type { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public bool IsReaded { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public ProtocolsEnum Protocol { get; set; }
    }
}
﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace NotificationService.Shared.Data
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
      //  public int NotificationProtocolId { get; set; }
       
        public NotificationProtocol Protocol { get; set; }
    }
}

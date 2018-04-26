using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class NotificationType : Base
    {
        public string Name { get; set; }

        public int? MessageTypeId { get; set; }

        [ForeignKey("MessageTypeId")]
        public MessageType MessageType { get; set; }

        public int? ContentTypeId { get; set; }

        [ForeignKey("ContentTypeId")]
        public NotificationContent NotificationContent { get; set; }
    }
}

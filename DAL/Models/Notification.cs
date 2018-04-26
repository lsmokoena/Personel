using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class Notification : Base
    {
        public int? PersonId { get; set; }

        [ForeignKey("PersonId")]
        public Person Person { get; set; }

        public int? UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public int? NotificationTypeId { get; set; }

        [ForeignKey("NotificationTypeId")]
        public Notification NotificationType { get; set; }
    }
}

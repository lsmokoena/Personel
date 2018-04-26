using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class NotificationContent : Base
    {
        public string Subject { get; set; }

        public string Body { get; set; }
    }
}

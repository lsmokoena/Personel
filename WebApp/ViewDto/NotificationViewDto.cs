using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personel.ViewDto
{
    public class NotificationViewDto
    {
        public int ID { get; set; }

        public int? PersonId { get; set; }

        public int? UserId { get; set; }

        public int? NotificationTypeId { get; set; }
    }
}

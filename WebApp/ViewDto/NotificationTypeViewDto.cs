using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personel.ViewDto
{
    public class NotificationTypeViewDto
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int? MessageTypeId { get; set; }

        public int? ContentTypeId { get; set; }
    }
}

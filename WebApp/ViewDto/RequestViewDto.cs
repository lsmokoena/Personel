using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personel.ViewDto
{
    public class RequestViewDto
    {
        public int ID { get; set; }

        public int? PersonId { get; set; }

        public int? UserId { get; set; }

        public string Note { get; set; }
    }
}

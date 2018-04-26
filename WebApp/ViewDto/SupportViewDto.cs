using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personel.ViewDto
{
    public class SupportViewDto
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string CellNumber { get; set; }
        public int SubjectId { get; set; }
        public string Message { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

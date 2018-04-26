using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personel.ViewDto
{
    public class PersonViewDto
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string IdNumber { get; set; }

        public string PassportNumber { get; set; }

        public byte[] Photo { get; set; }

        public List<SkillViewDto> Skills { get; set; }
    }
}

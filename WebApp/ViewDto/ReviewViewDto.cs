using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personel.ViewDto
{
    public class ReviewViewDto
    {
        public int ID { get; set; }

        public int PersonId { get; set; }

        public int SkillId { get; set; }
        
        public int UserId { get; set; }
        
        public int Level { get; set; }

        public string Remark { get; set; }
    }
}

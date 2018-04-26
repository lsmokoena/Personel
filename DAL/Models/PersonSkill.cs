using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class PersonSkill
    {
        public int PersonId { get; set; }

        public int SkillId { get; set; }

        public virtual Person Person { get; set; }

        public virtual Skill Skill { get; set; }
    }
}

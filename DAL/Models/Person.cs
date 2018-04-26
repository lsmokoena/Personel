using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class Person : Base
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string IdNumber { get; set; }

        public string PassportNumber { get; set; }

        public byte[] Photo { get; set; }
        
        public virtual ICollection<PersonSkill> PersonSkill { get; set; }
    }
}

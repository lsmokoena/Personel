using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class Skill : Base
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public virtual ICollection<PersonSkill> PersonSkill { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class Review : Base
    {
        public int PersonId { get; set; }

        [ForeignKey("PersonId")]
        public Person Person { get; set; }

        public int SkillId { get; set; }

        [ForeignKey("SkillId")]
        public Skill Skill { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public int Level { get; set; }

        public string Remark { get; set; }
    }
}

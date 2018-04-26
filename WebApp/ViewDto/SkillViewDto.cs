﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personel.ViewDto
{
    public class SkillViewDto
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int? CategoryId { get; set; }

        public virtual List<PersonViewDto> Persons { get; set; }
    }
}

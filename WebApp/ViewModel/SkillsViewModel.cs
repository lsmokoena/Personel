using Personel.ViewDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personel.ViewModel
{
    public class SkillsViewModel : BaseViewModel
    {
        public SkillsViewModel()
        {
            Skills = new List<SkillViewDto>();
        }

        public List<SkillViewDto> Skills { get; set; }
    }
}

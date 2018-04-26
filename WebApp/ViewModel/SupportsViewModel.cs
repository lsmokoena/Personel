using Personel.ViewDto;
using Personel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personel.ViewModel
{
    public class SupportsViewModel : BaseViewModel
    {
        public SupportsViewModel()
        {
            Supports = new List<SupportViewDto>();
        }

        public List<SupportViewDto> Supports { get; set; }
    }
}

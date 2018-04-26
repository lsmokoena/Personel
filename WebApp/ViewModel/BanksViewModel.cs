using Personel.ViewDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personel.ViewModel
{
    public class BanksViewModel : BaseViewModel
    {
        public BanksViewModel()
        {
            Banks = new List<BankViewDto>();
        }

        public List<BankViewDto> Banks { get; set; }
    }
}

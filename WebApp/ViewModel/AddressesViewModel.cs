using Personel.ViewDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personel.ViewModel
{
    public class AddressesViewModel : BaseViewModel
    {
        public AddressesViewModel()
        {
            Addresses = new List<AddressViewDto>();
        }

        public List<AddressViewDto> Addresses { get; set; }
    }
}

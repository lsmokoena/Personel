using Personel.ViewDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personel.ViewModel
{
    public class CountriesViewModel : BaseViewModel
    {
        public CountriesViewModel()
        {
            Countries = new List<CountryViewDto>();
        }

        public List<CountryViewDto> Countries { get; set; }
    }
}

using Personel.ViewDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personel.ViewModel
{
    public class LocationsViewModel : BaseViewModel
    {
        public LocationsViewModel()
        {
            Locations = new List<LocationViewDto>();
        }

        public List<LocationViewDto> Locations { get; set; }
    }
}

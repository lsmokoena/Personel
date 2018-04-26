using Personel.ViewDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personel.ViewModel
{
    public class PersonsViewModel : BaseViewModel
    {
        public PersonsViewModel()
        {
            Persons = new List<PersonViewDto>();
        }

        public List<PersonViewDto> Persons { get; set; }
    }
}

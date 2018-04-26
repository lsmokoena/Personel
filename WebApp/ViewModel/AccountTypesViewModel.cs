using Personel.ViewDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personel.ViewModel
{
    public class AccountTypesViewModel : BaseViewModel
    {
        public List<AccountTypeViewDto> AccountTypes { get; set; }
    }
}

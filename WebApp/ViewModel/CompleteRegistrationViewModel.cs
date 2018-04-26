using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Personel.ViewDto;

namespace Personel.ViewModel
{
    public class CompleteRegistrationViewModel : BaseViewModel
    {
        public int UserId { get; set; }
        public int BankId { get; set; }
        public int AccountTypeId { get; set; }
        public int AccountNumber { get; set; }
        public List<BankViewDto> Banks { get; set; }
        public List<AccountTypeViewDto> AccountTypes { get; set; }
    }
}

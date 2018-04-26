using Personel.ViewDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personel.ViewModel
{
    public class NotificationTypesViewModel : BaseViewModel
    {
        public NotificationTypesViewModel()
        {
            NotificationTypes = new List<NotificationTypeViewDto>();
        }

        public List<NotificationTypeViewDto> NotificationTypes { get; set; }
    }
}

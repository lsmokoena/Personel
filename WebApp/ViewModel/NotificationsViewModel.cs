using Personel.ViewDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personel.ViewModel
{
    public class NotificationsViewModel : BaseViewModel
    {
        public NotificationsViewModel()
        {
            Notifications = new List<NotificationViewDto>();
        }

        public List<NotificationViewDto> Notifications { get; set; }
    }
}

using Personel.ViewDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personel.ViewModel
{
    public class NotificationsContentViewModel : BaseViewModel
    {
        public NotificationsContentViewModel()
        {
            NotificationContents = new List<NotificationContentViewDto>();
        }

        public List<NotificationContentViewDto> NotificationContents { get; set; }
    }
}

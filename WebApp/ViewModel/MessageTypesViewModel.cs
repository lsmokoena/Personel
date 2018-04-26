using Personel.ViewDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personel.ViewModel
{
    public class MessageTypesViewModel : BaseViewModel
    {
        public MessageTypesViewModel()
        {
            MessageTypes = new List<MessageTypeViewDto>();
        }

        public List<MessageTypeViewDto> MessageTypes { get; set; }
    }
}

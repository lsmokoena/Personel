using Personel.ViewDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personel.ViewModel
{
    public class RequestsViewModel : BaseViewModel
    {
        public RequestsViewModel()
        {
            Requests = new List<RequestViewDto>();
        }

        public List<RequestViewDto> Requests { get; set; }
    }
}

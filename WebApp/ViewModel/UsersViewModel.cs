using Personel.ViewDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Personel.ViewModel
{
    public class UsersViewModel : BaseViewModel
    {
        public List<UserViewDto> Users { get; set; }
    }
}

using System.Collections.Generic;
using DAL.Models;
using Personel.ViewDto;

namespace Personel.ViewModel
{
    public class ResetPasswordViewModel : BaseViewModel
    {
        public string Password;
        public string ConfirmPassword;
    }
}

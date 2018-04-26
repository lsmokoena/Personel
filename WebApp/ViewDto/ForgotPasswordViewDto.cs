using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Personel.ViewDto
{
    public class ForgotPasswordViewDto
    {
        [Required(ErrorMessage = "Please enter an email address", AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessage = "Invalid email address. Please re-enter")]
        public String Email { get; set; }

    }
}

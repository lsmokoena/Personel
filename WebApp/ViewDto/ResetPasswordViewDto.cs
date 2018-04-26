using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Personel.ViewDto
{
    public class ResetPasswordViewDto
    {
        [Required(ErrorMessage = "Please enter new password", AllowEmptyStrings = false)]
        public String Password { get; set; }

        [Required(ErrorMessage = "Please enter confirmed password", AllowEmptyStrings = false)]
        public String ConfirmPassword { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Personel.ViewDto
{
    public class LoginViewDto
    {
        [Required(ErrorMessage = "Please enter a username", AllowEmptyStrings = false)]
        public String Username { get; set; }

        [Required(ErrorMessage = "Please enter password", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public String Password { get; set; }
    }
}

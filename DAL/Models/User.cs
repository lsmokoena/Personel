using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class User : Base
    {
        public User()
        {
            ClearPassword = DAL.Util.PasswordHelper.GeneratePassword();
            HashedPassword = DAL.Util.PasswordHelper.GetStringHash(ClearPassword);
            Active = true;
        }

        public String Email { get; set; }

        public String Name { get; set; }
        
        public String FirstName { get; set; }
        
        public String LastName { get; set; }

        public String TelephoneNumber { get; set; }

        public string HashedPassword { get; set; }

        public string ClearPassword { get; set; }

        public string ForgottenPasswordToken { get; set; }

        public string VerifyAccountToken { get; set; }

        public string ProfilePic { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Personel.ViewDto
{
    public class UserViewDto
    {
        public UserViewDto()
        {
            Active = true;
        }

        public int ID { get; set; }

        public String Email { get; set; }

        public String Name { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String TelephoneNumber { get; set; }

        public Boolean? Active { get; set; }

        public string ProfilePic { get; set; }

        public int BankAccountId { get; set; }

        public string AccountNumber { get; set; }

        public BankViewDto Bank { get; set; }

        public AccountTypeViewDto AccountType { get; set; }
    }
}

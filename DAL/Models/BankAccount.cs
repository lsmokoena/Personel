using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class BankAccount : Base
    {
        public int? AccountTypeId { get; set; }

        [ForeignKey("AccountTypeId")]
        public AccountType AccountType { get; set; }

        public string AccountNumber { get; set; }

        public int? BankId { get; set; }

        [ForeignKey("BankId")]
        public Bank Bank { get; set; }

        public int? PersonId { get; set; }

        [ForeignKey("PersonId")]
        public Person Person { get; set; }
    }
}

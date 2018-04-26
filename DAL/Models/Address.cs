using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class Address : Base
    {
        public string Email { get; set; }

        public string Apartment { get; set; }

        public string Street { get; set; }

        public string Suburb { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public int? CountryId { get; set; }

        [ForeignKey("CountryId")]
        public Country Country { get; set; }

        public int? PersonId { get; set; }

        [ForeignKey("PersonId")]
        public Person Person { get; set; }
    }
}

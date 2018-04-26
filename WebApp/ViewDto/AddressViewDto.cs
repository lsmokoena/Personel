using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personel.ViewDto
{
    public class AddressViewDto
    {
        public int ID { get; set; }

        public string Email { get; set; }

        public string Apartment { get; set; }

        public string Street { get; set; }

        public string Suburb { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public int? CountryId { get; set; }

        public int? PersonId { get; set; }
    }
}

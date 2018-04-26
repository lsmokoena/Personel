using System;
using System.Collections.Generic;
using System.Text;
using DAL.Interface;
using DAL.Models;

namespace DAL.Repository
{
    public class CountryRepository : GenericDataRepository<Country>, ICountryRepository
    {
        public CountryRepository(PersonelContext context, Serilog.ILogger logger) : base(context, logger)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using DAL.Interface;
using DAL.Models;

namespace DAL.Repository
{
    public class PersonRepository : GenericDataRepository<Person>, IPersonRepository
    {
        public PersonRepository(PersonelContext context, Serilog.ILogger logger) : base(context, logger)
        {
        }
    }
}

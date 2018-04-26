using System;
using System.Collections.Generic;
using System.Text;
using DAL.Interface;
using DAL.Models;

namespace DAL.Repository
{
    public class BankAccountRepository : GenericDataRepository<BankAccount>, IBankAccountRepository
    {
        public BankAccountRepository(PersonelContext context, Serilog.ILogger logger) : base(context, logger)
        {
        }
    }
}

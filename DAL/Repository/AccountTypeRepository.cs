using System;
using System.Collections.Generic;
using System.Text;
using DAL.Interface;
using DAL.Models;

namespace DAL.Repository
{
    public class AccountTypeRepository : GenericDataRepository<AccountType>, IAccountTypeRepository
    {
        public AccountTypeRepository(PersonelContext context, Serilog.ILogger logger) : base(context, logger)
        {
        }
    }
}

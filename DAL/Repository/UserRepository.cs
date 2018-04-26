using System;
using System.Collections.Generic;
using System.Text;
using DAL.Interface;
using DAL.Models;

namespace DAL.Repository
{
    public class UserRepository : GenericDataRepository<User>, IUserRepository
    {
        public UserRepository(PersonelContext context, Serilog.ILogger logger) : base(context, logger)
        {
        }
    }
}

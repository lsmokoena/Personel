using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class RequestRepository : GenericDataRepository<Request>, IRequestRepository
    {
        public RequestRepository(PersonelContext context, Serilog.ILogger logger) : base(context, logger)
        {
        }
    }
}

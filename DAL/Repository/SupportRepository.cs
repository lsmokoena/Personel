using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class SupportRepository : GenericDataRepository<Support>, ISupportRepository
    {
        public SupportRepository(PersonelContext context, Serilog.ILogger logger) : base(context, logger)
        {
        }
    }
}

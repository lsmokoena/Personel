using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class LocationRepository : GenericDataRepository<Location>, ILocationRepository
    {
        public LocationRepository(PersonelContext context, Serilog.ILogger logger) : base(context, logger)
        {
        }
    }
}

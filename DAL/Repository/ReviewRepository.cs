using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class ReviewRepository : GenericDataRepository<Review>, IReviewRepository
    {
        public ReviewRepository(PersonelContext context, Serilog.ILogger logger) : base(context, logger)
        {
        }
    }
}

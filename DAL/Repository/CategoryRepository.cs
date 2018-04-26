using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class CategoryRepository : GenericDataRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(PersonelContext context, Serilog.ILogger logger) : base(context, logger)
        {
        }
    }
}

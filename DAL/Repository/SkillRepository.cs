using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class SkillRepository : GenericDataRepository<Skill>, ISkillRepository
    {
        public SkillRepository(PersonelContext context, Serilog.ILogger logger) : base(context, logger)
        {
        }
    }
}

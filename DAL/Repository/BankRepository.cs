﻿using System;
using System.Collections.Generic;
using System.Text;
using DAL.Interface;
using DAL.Models;

namespace DAL.Repository
{
    public class BankRepository : GenericDataRepository<Bank>, IBankRepository
    {
        public BankRepository(PersonelContext context, Serilog.ILogger logger) : base(context, logger)
        {
        }
    }
}

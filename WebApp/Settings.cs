using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dream
{
    public class ApplicationSettings
    {
        public string ConnectionString { get; set; }

        public ApplicationSettings(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
    }
}

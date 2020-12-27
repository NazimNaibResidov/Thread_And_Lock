using MonyTansfer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonyTansfer.Data
{
    public class TrasferDbContext : DbContext
    {
        public TrasferDbContext() : base("test")
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}

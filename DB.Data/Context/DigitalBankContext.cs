using DB.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Data.Context
{
    public class DigitalBankContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public DigitalBankContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
    }
}

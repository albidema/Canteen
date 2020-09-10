using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Canteen.Models;

namespace Canteen.Data
{
    public class CanteenContext : DbContext
    {
        public CanteenContext (DbContextOptions<CanteenContext> options)
            : base(options)
        {
        }

        public DbSet<Container> Container { get; set; }
        public DbSet<Sector> Sector { get; set; }
        public DbSet<Operation> Operation { get; set; }
    }
}

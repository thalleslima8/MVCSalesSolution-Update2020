using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCSalesSolution.Models;

namespace MVCSalesSolution.Data
{
    public class MVCSalesSolutionContext : DbContext
    {
        public MVCSalesSolutionContext (DbContextOptions<MVCSalesSolutionContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
    }
}

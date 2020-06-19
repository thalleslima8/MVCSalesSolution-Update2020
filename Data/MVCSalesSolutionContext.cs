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

        public DbSet<MVCSalesSolution.Models.Department> Department { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using PlanetumDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetumInfrastructure.Data
{
    public class PlanetumDbContext :DbContext
    {
        public PlanetumDbContext(DbContextOptions<PlanetumDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inspection>().HasKey(s => s.CompanyId);
        }

        public DbSet<Inspection> Inspections { get; set; }

       
    }
}

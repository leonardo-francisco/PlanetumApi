using Microsoft.EntityFrameworkCore;
using PlanetumDomain.Entities;
using PlanetumDomain.Interfaces;
using PlanetumInfrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetumInfrastructure.Repositories
{
    public class InspectionRepository : IInspectionRepository
    {
        private readonly PlanetumDbContext _context;

        public InspectionRepository(PlanetumDbContext context)
        {
            _context = context;
        }

        public async Task<Inspection> Create(Inspection inspection)
        {
            try
            {
                _context.Inspections.Add(inspection);
                await _context.SaveChangesAsync();
                return inspection;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<Inspection>> GetAll()
        {
            return await _context.Inspections.ToListAsync();
        }
    }
}

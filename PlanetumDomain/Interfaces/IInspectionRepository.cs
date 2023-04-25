using PlanetumDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetumDomain.Interfaces
{
    public interface IInspectionRepository
    {
        Task<List<Inspection>> GetAll();
        Task<Inspection> Create(Inspection inspection);
    }
}

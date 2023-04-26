using PlanetumApplication.Dto;
using PlanetumDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetumApplication.Services
{
    public interface IInspectionService
    {
        Task<List<InspectionDto>> GetAllInspections();
        Task<InspectionDto> CreateInspection(InspectionDto inspection);
    }
}

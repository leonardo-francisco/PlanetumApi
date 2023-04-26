using AutoMapper;
using PlanetumApplication.Dto;
using PlanetumDomain.Entities;
using PlanetumDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetumApplication.Services
{
    public class InspectionService : IInspectionService
    {
        private readonly IInspectionRepository _inspectionRepository;
        private readonly IMapper _mapper;

        public InspectionService(IInspectionRepository inspectionRepository, IMapper mapper)
        {
            _inspectionRepository = inspectionRepository;
            _mapper = mapper;
        }

        public async Task<InspectionDto> CreateInspection(InspectionDto inspection)
        {
            var inspectionEntity = _mapper.Map<Inspection>(inspection);
            var createdInspection = await _inspectionRepository.Create(inspectionEntity);
            return _mapper.Map<InspectionDto>(createdInspection);
        }

        public async Task<List<InspectionDto>> GetAllInspections()
        {
            var inspections = await _inspectionRepository.GetAll();
            return _mapper.Map<List<InspectionDto>>(inspections);
        }
    }
}

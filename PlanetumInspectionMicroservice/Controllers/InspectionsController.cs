using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlanetumDomain.Entities;
using PlanetumDomain.Interfaces;

namespace PlanetumInspectionMicroservice.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class InspectionsController : ControllerBase
    {
        private readonly IInspectionRepository _inspectionRepository;

        public InspectionsController(IInspectionRepository inspectionRepository)
        {
            _inspectionRepository = inspectionRepository;
        }

        [HttpGet]
        [Route("allInspections")]
        public async Task<IActionResult> GetAllInspections()
        {
            var inspections = await _inspectionRepository.GetAll();
            return Ok(inspections);
        }

        [HttpPost]
        [Route("createInspection")]
        public async Task<IActionResult> CreateInspection([FromBody] Inspection inspection)
        {
            try
            {
                var response = await _inspectionRepository.Create(inspection);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

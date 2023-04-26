using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlanetumApplication.Dto;
using PlanetumApplication.Services;
using PlanetumApplication.Validator;


namespace PlanetumInspectionMicroservice.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class InspectionsController : ControllerBase
    {
        private readonly IInspectionService _service;
        private readonly IValidator<InspectionDto> _validator;

        public InspectionsController(IInspectionService service, IValidator<InspectionDto> validator)
        {           
            _service = service; 
            _validator = validator;
        }

        [HttpGet]
        [Route("allInspections")]
        public async Task<IActionResult> GetAllInspections()
        {
            var inspections = await _service.GetAllInspections();
            return Ok(inspections);
        }

        [HttpPost]
        [Route("createInspection")]
        public async Task<IActionResult> CreateInspection([FromBody] InspectionDto inspection)
        {
            try
            {
                ValidationResult result = await _validator.ValidateAsync(inspection);
                if (!result.IsValid)
                {
                    result.AddToModelState(this.ModelState, null);
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                var response = await _service.CreateInspection(inspection);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

using FluentValidation;
using PlanetumApplication.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetumApplication.Validator
{
    public class InspectionsValidator : AbstractValidator<InspectionDto>
    {
        public InspectionsValidator()
        {
            RuleFor(x => x.BrokerCode)
                .NotEmpty().WithMessage("Broker Code cannot be empty or null");
            RuleFor(x => x.ProductCode)
                .NotEmpty().WithMessage("Product Code cannot be empty or null");
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Product Name cannot be empty or null");
            RuleFor(x => x.InspectionNumber)
                .NotEmpty().WithMessage("Inspection Number cannot be empty or null");
            
        }
    }
}

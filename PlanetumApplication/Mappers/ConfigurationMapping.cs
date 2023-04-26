using AutoMapper;
using Microsoft.AspNetCore.Components.Forms;
using PlanetumApplication.Dto;
using PlanetumDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetumApplication.Mappers
{
    public class ConfigurationMapping : Profile
    {
        public ConfigurationMapping()
        {
            CreateMap<Inspection, InspectionDto>().ReverseMap();

        }
    }
}

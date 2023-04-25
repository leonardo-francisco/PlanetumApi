using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetumDomain.Entities
{
    public class Inspection
    {        
        public int CompanyId { get; set; }
        public string BrokerCode { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string InspectionNumber { get; set; }
    }
}

using Insurance.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.DTOs
{
    public class PolicyCreateDto
    {
        public string PolicyNumber { get; set; }
        public InsuranceType Type { get; set; }
        public decimal Coverage { get; set; }
        public decimal Premium { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int InsuredId { get; set; }
    }
}

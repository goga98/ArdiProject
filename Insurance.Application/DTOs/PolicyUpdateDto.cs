using Insurance.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.DTOs
{
    public class PolicyUpdateDto
    {
        public int Id { get; set; }
        public string PolicyNumber { get; set; }
        public InsuranceType Type { get; set; }
        public decimal Coverage { get; set; }
        public decimal Premium { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public PolicyStatus Status { get; set; }
        public int InsuredId { get; set; }
    }
}

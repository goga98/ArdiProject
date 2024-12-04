using Insurance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Interfaces
{
    public interface IPolicyRepository : IRepository<InsurancePolicy>
    {
        Task<IEnumerable<InsurancePolicy>> GetByInsuredIdAsync(int insuredId);
    }
}

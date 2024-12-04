using Insurance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Interfaces
{
    public interface IInsuredRepository : IRepository<Insured>
    {
        Task<Insured> GetWithPoliciesAsync(int id);
        Task<IEnumerable<Insured>> GetAllWithPoliciesAsync();
    }
}

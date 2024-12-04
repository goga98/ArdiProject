using Insurance.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.Services.Interfaces
{
    public interface IPolicyService
    {
        Task<IEnumerable<PolicyDto>> GetAllAsync();
        Task<PolicyDto> GetByIdAsync(int id);
        Task<PolicyDto> CreateAsync(PolicyCreateDto policyDto);
        Task<PolicyDto> UpdatePolicy(PolicyUpdateDto policyDto);
        Task<(bool Succeeded, string Message)> DeleteAsync(int id);
    }
}

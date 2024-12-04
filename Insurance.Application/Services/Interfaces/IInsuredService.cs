using Insurance.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.Services.Interfaces
{
    public interface IInsuredService
    {
        Task<IEnumerable<InsuredDto>> GetAllAsync();
        Task<InsuredDto> GetByIdAsync(int id);
        Task<InsuredDto> CreateAsync(InsuredCreateDto insuredDto);
        Task<InsuredDto> UpdateInsuredAsync(InsuredUpdateDto insuredDto);
        Task<(bool Succeeded, string Message)> DeleteAsync(int id);
    }
}

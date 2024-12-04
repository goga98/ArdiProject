using AutoMapper;
using Insurance.Application.DTOs;
using Insurance.Application.Services.Interfaces;
using Insurance.Domain.Entities;
using Insurance.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.Services
{
    public class PolicyService : IPolicyService
    {
        private readonly IPolicyRepository _policyRepository;
        private readonly IMapper _mapper;

        public PolicyService(IPolicyRepository policyRepository, IMapper mapper)
        {
            _policyRepository = policyRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PolicyDto>> GetAllAsync()
        {
            var policies = await _policyRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PolicyDto>>(policies);
        }

        public async Task<PolicyDto> GetByIdAsync(int id)
        {
            var policy = await _policyRepository.GetByIdAsync(id);
            return _mapper.Map<PolicyDto>(policy);
        }

        public async Task<IEnumerable<PolicyDto>> GetByInsuredIdAsync(int insuredId)
        {
            var policies = await _policyRepository.GetByInsuredIdAsync(insuredId);
            return _mapper.Map<IEnumerable<PolicyDto>>(policies);
        }

        public async Task<PolicyDto> CreateAsync(PolicyCreateDto policyDto)
        {
            var policy = _mapper.Map<InsurancePolicy>(policyDto);
            var result = await _policyRepository.AddAsync(policy);
            return _mapper.Map<PolicyDto>(result);
        }

        public async Task<PolicyDto> UpdatePolicy(PolicyUpdateDto policyDto)
        {
            var policy = _mapper.Map<InsurancePolicy>(policyDto);
            await _policyRepository.UpdateAsync(policy);
            return _mapper.Map<PolicyDto>(policy);
        }
        public async Task<(bool Succeeded, string Message)> DeleteAsync(int id)
        {
            try
            {
                var entity = await _policyRepository.GetByIdAsync(id);
                if (entity == null)
                    return (false, "ჩანაწერი ვერ მოიძებნა");

                await _policyRepository.DeleteAsync(id);
                return (true, "წარმატებით წაიშალა");
            }
            catch (Exception)
            {
                return (false, "ჩანაწერის წაშლა ვერ მოხერხდა. შეამოწმეთ დაკავშირებული ჩანაწერები");
            }
        }
    }
}

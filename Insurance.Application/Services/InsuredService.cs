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
    public class InsuredService : IInsuredService
    {
        private readonly IInsuredRepository _insuredRepository;
        private readonly IMapper _mapper;

        public InsuredService(IInsuredRepository insuredRepository, IMapper mapper)
        {
            _insuredRepository = insuredRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InsuredDto>> GetAllAsync()
        {
            var insureds = await _insuredRepository.GetAllWithPoliciesAsync();
            return _mapper.Map<IEnumerable<InsuredDto>>(insureds);
        }

        public async Task<InsuredDto> GetByIdAsync(int id)
        {
            var insured = await _insuredRepository.GetWithPoliciesAsync(id);
            return _mapper.Map<InsuredDto>(insured);
        }

        public async Task<InsuredDto> CreateAsync(InsuredCreateDto insuredDto)
        {
            var insured = _mapper.Map<Insured>(insuredDto);
            var result = await _insuredRepository.AddAsync(insured);
            return _mapper.Map<InsuredDto>(result);
        }

        public async Task<InsuredDto> UpdateInsuredAsync(InsuredUpdateDto insuredDto)
        {
            var insured = _mapper.Map<Insured>(insuredDto);
            await _insuredRepository.UpdateAsync(insured);
            return _mapper.Map<InsuredDto>(insured);
        }

        public async Task<(bool Succeeded, string Message)> DeleteAsync(int id)
        {
            try
            {
                var entity = await _insuredRepository.GetByIdAsync(id);
                if (entity == null)
                    return (false, "ჩანაწერი ვერ მოიძებნა");

                await _insuredRepository.DeleteAsync(id);
                return (true, "წარმატებით წაიშალა");
            }
            catch (Exception)
            {
                return (false, "ჩანაწერის წაშლა ვერ მოხერხდა. შეამოწმეთ დაკავშირებული ჩანაწერები");
            }
        }
    }
}

using AutoMapper;
using Insurance.Application.DTOs;
using Insurance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Insurance.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<InsuredUpdateDto, Insured>()
    .ForMember(dest => dest.Policies, opt => opt.Ignore())
    .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
    .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());

            CreateMap<InsuredCreateDto, Insured>()
    .ForMember(dest => dest.Policies, opt => opt.Ignore())
    .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
    .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
            CreateMap<InsuredDto, Insured>()
    .ForMember(dest => dest.Policies, opt => opt.Ignore())
    .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
    .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());

            CreateMap<Insured, InsuredDto>()
                .ForMember(dest => dest.Policies, opt => opt.MapFrom(src => src.Policies));

            CreateMap<PolicyCreateDto, InsurancePolicy>()
    .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
    .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
            CreateMap<PolicyUpdateDto, InsurancePolicy>()
    .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
    .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());

            CreateMap<InsurancePolicy, PolicyDto>();
        }
    }
}

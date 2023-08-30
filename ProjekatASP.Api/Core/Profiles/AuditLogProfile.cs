﻿using AutoMapper;
using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.Domain;

namespace ProjekatASP.Api.Core.Profiles
{
    public class AuditLogProfile : Profile
    {
        public AuditLogProfile()
        {
            CreateMap<UseCaseLog, AuditLogsDto>()
            .ForMember(dto => dto.Date, opt => opt.MapFrom(uc => uc.Date))
            .ForMember(dto => dto.UseCaseName, opt => opt.MapFrom(uc => uc.UseCaseName))
            .ForMember(dto => dto.Data, opt => opt.MapFrom(uc => uc.Data))
            .ForMember(dto => dto.Actor, opt => opt.MapFrom(uc => uc.Actor));
        }
    }
}

using AutoMapper;
using InnovationAdmin.Application.Features.SysPrefCompanies.Commands.CreateSysPrefCompany;
using InnovationAdmin.Application.Features.SysPrefCompanies.Commands.UpdateSysPrefCompany;
using InnovationAdmin.Application.Features.SysPrefCompanies.Queries.GetSysPrefCompanyQuery;
using InnovationAdmin.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace InnovationAdmin.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<SysPrefCompany, CreateSysPrefCompanyDto>().ReverseMap();
           CreateMap<SysPrefCompany, SysPrefCompanyDto>().ReverseMap();
            CreateMap<SysPrefCompany, UpdateSysPrefCompanyDto>().ReverseMap();
            //CreateMap<Event, UpdateEventCommand>().ReverseMap();
            //CreateMap<Event, EventDetailVm>().ReverseMap();
            //CreateMap<Event, CategoryEventDto>().ReverseMap();
            //CreateMap<Event, EventExportDto>().ReverseMap();



        }
    }
}

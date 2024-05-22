using AutoMapper;
using InnovationAdmin.Application.Features.SysPref_GeneralBehaviour.Commands.Create_SysPref_GeneralBehaviour;
using InnovationAdmin.Application.Features.SysPref_GeneralBehaviour.Commands.Update_SysPref_GeneralBehaviour;
using InnovationAdmin.Application.Features.SysPref_GeneralBehaviour.Queries.Get_SysPref_GeneralBehaviour_List;
using InnovationAdmin.Application.Features.SysPref_GeneralBehaviour.Queries.GetById_SysPref_GeneralBehaviour;
using InnovationAdmin.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace InnovationAdmin.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<SysPref_GeneralBehaviours, Create_SysPref_GeneralBehaviour_Command>().ReverseMap();
            
            CreateMap<SysPref_GeneralBehaviours, Update_SysPref_GeneralBehaviour_Command>().ReverseMap();
            CreateMap<SysPref_GeneralBehaviours, SysPref_GeneralBehaviour_ListVM>().ReverseMap();
          
            CreateMap<SysPref_GeneralBehaviours, Create_SysPref_GeneralBehaviour_Dto>();
            CreateMap<SysPref_GeneralBehaviours, SysPref_GeneralBehaviour_ListVM>();
            CreateMap<SysPref_GeneralBehaviours, Create_SysPref_GeneralBehaviour_Command>();
            
            CreateMap<SysPref_GeneralBehaviours, Update_SysPref_GeneralBehaviour_Command>().ReverseMap();
            CreateMap<SysPref_GeneralBehaviours, Get_SysPref_GeneralBehaviour_List_Query>().ReverseMap();
            CreateMap<SysPref_GeneralBehaviours, GetById_SysPref_GeneralBehaviours_VM>();


        }
    }
}

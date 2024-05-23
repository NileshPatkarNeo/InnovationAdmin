using AutoMapper;
using InnovationAdmin.Application.Features.AdminRoles.Commands.CreateAdminRole;
using InnovationAdmin.Application.Features.AdminRoles.Commands.DeleteAdminRole;
using InnovationAdmin.Application.Features.AdminRoles.Commands.UpdateAdminRole;
using InnovationAdmin.Application.Features.AdminRoles.Queries.GetAdminRole;
using InnovationAdmin.Application.Features.AdminRoles.Queries.GetAdminRoleList;
using InnovationAdmin.Application.Features.SysPref_GeneralBehaviour.Commands.Create_SysPref_GeneralBehaviour;
using InnovationAdmin.Application.Features.SysPref_GeneralBehaviour.Commands.Update_SysPref_GeneralBehaviour;
using InnovationAdmin.Application.Features.SysPref_GeneralBehaviour.Queries.Get_SysPref_GeneralBehaviour_List;
using InnovationAdmin.Application.Features.SysPref_GeneralBehaviour.Queries.GetById_SysPref_GeneralBehaviour;
using InnovationAdmin.Application.Features.Admin_Users.Commands.CreateAdmin_User;
using InnovationAdmin.Application.Features.Admin_Users.Commands.CreateAdminUser;
using InnovationAdmin.Application.Features.Admin_Users.Commands.DeleteAdminUser;
using InnovationAdmin.Application.Features.Admin_Users.Commands.UpdateAdminUser;
using InnovationAdmin.Application.Features.Admin_Users.Queries.GetAdminUserById;
using InnovationAdmin.Application.Features.Admin_Users.Queries.GetAdminUserList;
using InnovationAdmin.Application.Features.SysPrefCompanies.Commands.CreateSysPrefCompany;
using InnovationAdmin.Application.Features.SysPrefCompanies.Commands.UpdateSysPrefCompany;
using InnovationAdmin.Application.Features.SysPrefCompanies.Queries.GetSysPrefCompanyQuery;
using InnovationAdmin.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace InnovationAdmin.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Admin_User, CreateAdminUserDto>();
            CreateMap<Admin_User, AdminUserListVm>().ReverseMap();

            CreateMap<Admin_User, CreateAdminUserCommand>();
            CreateMap<Admin_User, UpdateAdminUserCommand>().ReverseMap();
            CreateMap<Admin_User, DeleteAdminUserCommand>();

            CreateMap<SysPrefCompany, CreateSysPrefCompanyDto>().ReverseMap();
            CreateMap<SysPrefCompany, SysPrefCompanyDto>().ReverseMap();
            CreateMap<SysPrefCompany, UpdateSysPrefCompanyDto>().ReverseMap();
    
            CreateMap<SysPref_GeneralBehaviours, Create_SysPref_GeneralBehaviour_Command>().ReverseMap();

            CreateMap<SysPref_GeneralBehaviours, Update_SysPref_GeneralBehaviour_Command>().ReverseMap();
            CreateMap<SysPref_GeneralBehaviours, SysPref_GeneralBehaviour_ListVM>().ReverseMap();
            CreateMap<Admin_User, AdminUserByIdVm>().ReverseMap();





            CreateMap<SysPref_GeneralBehaviours, Create_SysPref_GeneralBehaviour_Dto>();
            CreateMap<SysPref_GeneralBehaviours, SysPref_GeneralBehaviour_ListVM>();
            CreateMap<SysPref_GeneralBehaviours, Create_SysPref_GeneralBehaviour_Command>();

            CreateMap<SysPref_GeneralBehaviours, Update_SysPref_GeneralBehaviour_Command>().ReverseMap();
            CreateMap<SysPref_GeneralBehaviours, Get_SysPref_GeneralBehaviour_List_Query>().ReverseMap();
            CreateMap<SysPref_GeneralBehaviours, GetById_SysPref_GeneralBehaviours_VM>();
        
    

       
           // CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
       
            CreateMap<SysPrefCompany, CreateSysPrefCompanyDto>().ReverseMap();
            CreateMap<SysPrefCompany, SysPrefCompanyDto>().ReverseMap();
            CreateMap<SysPrefCompany, UpdateSysPrefCompanyDto>().ReverseMap();
            
         

            CreateMap<Admin_Role, AdminRoleVM>();
            CreateMap<Admin_Role, CreateAdminRoleCommand>();
            CreateMap<Admin_Role, CreateAdminRoleCommand>();
            CreateMap<Admin_Role, DeleteAdminRoleCommand>();
            CreateMap<Admin_Role, UpdateAdminRoleCommand>();
            CreateMap<Admin_Role, AdminRoleListVm>();



            // CreateMap<Category, UpdateCategoryCommand>().ReverseMap();

            CreateMap<Admin_Role, AdminRoleVM>().ReverseMap();
            CreateMap<Admin_Role, CreateAdminRoleCommand>().ReverseMap();
            CreateMap<Admin_Role, CreateAdminRoleCommand>().ReverseMap();
            CreateMap<Admin_Role, DeleteAdminRoleCommand>().ReverseMap();
            CreateMap<Admin_Role, UpdateAdminRoleCommand>().ReverseMap();
            CreateMap<Admin_Role, AdminRoleListVm>().ReverseMap();

            CreateMap<Admin_Role, CreateAdminRoleDto>();
        }
    }
}

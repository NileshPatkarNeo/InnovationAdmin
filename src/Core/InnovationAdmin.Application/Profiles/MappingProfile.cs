using AutoMapper;
using InnovationAdmin.Application.Features.AdminRoles.Commands.CreateAdminRole;
using InnovationAdmin.Application.Features.AdminRoles.Commands.DeleteAdminRole;
using InnovationAdmin.Application.Features.AdminRoles.Commands.UpdateAdminRole;
using InnovationAdmin.Application.Features.AdminRoles.Queries.GetAdminRole;
using InnovationAdmin.Application.Features.AdminRoles.Queries.GetAdminRoleList;
using InnovationAdmin.Application.Features.Admin_Users.Commands.CreateAdmin_User;
using InnovationAdmin.Application.Features.Admin_Users.Commands.CreateAdminUser;
using InnovationAdmin.Application.Features.Admin_Users.Commands.DeleteAdminUser;
using InnovationAdmin.Application.Features.Admin_Users.Commands.UpdateAdminUser;
using InnovationAdmin.Application.Features.Admin_Users.Queries.GetAdminUserList;
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
            CreateMap<Admin_User, CreateAdminUserDto>();
            CreateMap<Admin_User, AdminUserListVm>().ReverseMap();
         
            CreateMap<Admin_User, CreateAdminUserCommand>();
            CreateMap<Admin_User, UpdateAdminUserCommand>().ReverseMap();
            CreateMap<Admin_User, DeleteAdminUserCommand>();
        
            CreateMap<SysPrefCompany, CreateSysPrefCompanyDto>().ReverseMap();
           CreateMap<SysPrefCompany, SysPrefCompanyDto>().ReverseMap();
            CreateMap<SysPrefCompany, UpdateSysPrefCompanyDto>().ReverseMap();
         

            CreateMap<Admin_Role, AdminRoleVM>();
            CreateMap<Admin_Role, CreateAdminRoleCommand>();
            CreateMap<Admin_Role, CreateAdminRoleCommand>();
            CreateMap<Admin_Role, DeleteAdminRoleCommand>();
            CreateMap<Admin_Role, UpdateAdminRoleCommand>();
            CreateMap<Admin_Role, AdminRoleListVm>();

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

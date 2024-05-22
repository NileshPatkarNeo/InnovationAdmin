﻿using AutoMapper;
using InnovationAdmin.Application.Features.AdminRoles.Commands.CreateAdminRole;
using InnovationAdmin.Application.Features.AdminRoles.Commands.DeleteAdminRole;
using InnovationAdmin.Application.Features.AdminRoles.Commands.UpdateAdminRole;
using InnovationAdmin.Application.Features.AdminRoles.Queries.GetAdminRole;
using InnovationAdmin.Application.Features.AdminRoles.Queries.GetAdminRoleList;
using InnovationAdmin.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace InnovationAdmin.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {

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

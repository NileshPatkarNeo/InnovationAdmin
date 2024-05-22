using AutoMapper;
using InnovationAdmin.Application.Features.Admin_Users.Commands.CreateAdmin_User;
using InnovationAdmin.Application.Features.Admin_Users.Commands.CreateAdminUser;
using InnovationAdmin.Application.Features.Admin_Users.Commands.DeleteAdminUser;
using InnovationAdmin.Application.Features.Admin_Users.Commands.UpdateAdminUser;
using InnovationAdmin.Application.Features.Admin_Users.Queries.GetAdminUserById;
using InnovationAdmin.Application.Features.Admin_Users.Queries.GetAdminUserList;
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
            CreateMap<Admin_User, AdminUserByIdVm>().ReverseMap();








            // CreateMap<Category, UpdateCategoryCommand>().ReverseMap();


        }
    }
}

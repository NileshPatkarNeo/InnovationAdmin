using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Responses;
using InnovationAdmin.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.Admin_Users.Queries.GetAdminUserById
{
    public class AdminUserByIdQueryHandler :  IRequestHandler<AdminUserByIdQuery, Response<AdminUserByIdVm>>
    {
        private readonly IAsyncRepository<Admin_User> _admiuserRepository;
   
        private readonly IMapper _mapper;

        private readonly IDataProtector _protector;
        public AdminUserByIdQueryHandler(IMapper mapper, IAsyncRepository<Admin_User> admiuserRepository,  IDataProtectionProvider provider)
        {
            _mapper = mapper;
           
            _admiuserRepository = admiuserRepository;
            _protector = provider.CreateProtector("");
        }

        public async Task<Response<AdminUserByIdVm>> Handle(AdminUserByIdQuery request, CancellationToken cancellationToken)
        {


            var @system = await _admiuserRepository.GetByIdAsync(new Guid(request.User_ID));
            var systemDto = _mapper.Map<AdminUserByIdVm>(system);


            if (@system == null)
            {
                throw new NotFoundException(nameof(AdminUserByIdVm), @system.User_ID);
            }

            var response = new Response<AdminUserByIdVm>(systemDto);
            return response;
        }


        //public async Task<Response<AdminUserByIdVm>> Handle(AdminUserByIdQuery request, CancellationToken cancellationToken)
        //{
        //    string id = _protector.Unprotect(request.User_ID);

        //    var @adminuser = await _admiuserRepository.GetByIdAsync(new Guid(id));
        //    var eventDetailDto = _mapper.Map<AdminUserByIdVm>(@adminuser);

        //    var category = await _admiuserRepository.GetByIdAsync(@adminuser.User_ID);

        //    if (category == null)
        //    {
        //        throw new NotFoundException(nameof(Admin_User), @adminuser.User_ID);
        //    }
        //    //eventDetailDto.User_Name = _mapper.Map<AdminUserByIdDto>(category);

        //    var response = new Response<AdminUserByIdVm>(eventDetailDto);
        //    return response;
        //}

        //public async Task<Response<AdminUserByIdVm>> Handle(AdminUserByIdQuery request, CancellationToken cancellationToken)
        //{


        //    var @adminRole = await _admiuserRepository.GetByIdAsync(request.User_ID);
        //    var adminRoleDetailDto = _mapper.Map<AdminUserByIdVm>(@adminRole);


        //    if (@adminRole == null)
        //    {
        //        throw new NotFoundException(nameof(AdminUserByIdVm), @adminRole.Role_ID);
        //    }

        //    var response = new Response<AdminUserByIdVm>(adminRoleDetailDto);
        //    return response;
        //}


    }
}

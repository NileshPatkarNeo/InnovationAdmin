using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.Admin_Users.Queries.GetAdminUserList
{
    public class AdminUserListQueryHandler : IRequestHandler<AdminUserListQuery, Response<IEnumerable<AdminUserListVm>>>
    {
        private readonly IAdminUserRepository _adminuserRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public AdminUserListQueryHandler(IMapper mapper, IAdminUserRepository adminuserRepository, ILogger<AdminUserListQueryHandler> logger)
        {
            _mapper = mapper;
            _adminuserRepository = adminuserRepository;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<AdminUserListVm>>> Handle(AdminUserListQuery request, CancellationToken cancellationToken)
         {
            _logger.LogInformation("Handle Initiated");
            var allAdminuser = (await _adminuserRepository.GetAdminUsersList()).OrderBy(x => x.User_Name).ToList();
            var adminuser = _mapper.Map<IEnumerable<AdminUserListVm>>(allAdminuser);
            _logger.LogInformation("Hanlde Completed");
            return new Response<IEnumerable<AdminUserListVm>>(adminuser, "success");
        }
    }
}

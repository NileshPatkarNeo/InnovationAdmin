using InnovationAdmin.Application.Features.Admin_Users.Commands.CreateAdminUser;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.Admin_Users.Commands.CreateAdmin_User
{
    public class CreateAdminUserCommand : IRequest<Response<CreateAdminUserDto>>
    {
       
        public string User_Name { get; set; }

        
        public string Password { get; set; }

      
        public Guid Role { get; set; }

       
        public string Email { get; set; }

      
        public bool Status { get; set; }
    }
}

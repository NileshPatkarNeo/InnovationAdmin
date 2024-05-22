using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.Admin_Users.Commands.DeleteAdminUser
{
    public class DeleteAdminUserCommand : IRequest
    {
        public String User_ID { get; set; }
    }
}

using InnovationAdmin.Application.Features.SysPrefCompanies.Commands.UpdateSysPrefCompany;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.PharmacyGroup.Commands.UpdatePharmacyGroup
{
    public class UpdatePharmacyGroupCommand : IRequest<Response<UpdatePharmacyGroupDto>>
    {
        public Guid Id { get; set; }
        public string PharmacyName { get; set; }
    }
}

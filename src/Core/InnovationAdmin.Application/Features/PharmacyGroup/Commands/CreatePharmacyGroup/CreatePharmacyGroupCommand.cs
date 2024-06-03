using InnovationAdmin.Application.Features.SysPrefCompanies.Commands.CreateSysPrefCompany;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.PharmacyGroup.Commands.CreatePharmacyGroup
{
    public class CreatePharmacyGroupCommand : IRequest<Response<CreatePharmacyGroupDto>>
    {
        public string PharmacyName { get; set; }
    }
}

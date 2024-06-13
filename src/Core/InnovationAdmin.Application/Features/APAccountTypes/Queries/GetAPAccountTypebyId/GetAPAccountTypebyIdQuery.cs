using InnovationAdmin.Application.Features.DataSources.Queries.GetDataSourceById;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.APAccountTypes.Queries.GetAPAccountTypebyId
{
    public class GetAPAccountTypebyIdQuery : IRequest<Response<GetAPAccountTypebyIdVm>>
    {
        public String ID { get; set; }

    }
}

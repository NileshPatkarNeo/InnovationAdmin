using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.DataSources.Commands.DeleteDataSource
{
    public class DeleteDataSourceCommand : IRequest
    {
        public Guid ID { get; set; }
    }
}

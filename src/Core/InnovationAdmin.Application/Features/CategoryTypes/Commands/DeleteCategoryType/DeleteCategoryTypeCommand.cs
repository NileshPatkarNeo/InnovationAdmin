using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.CategoryTypes.Commands.DeleteCategoryType
{
    public class DeleteCategoryTypeCommand : IRequest
    {
        public Guid ID { get; set; }
    }
}

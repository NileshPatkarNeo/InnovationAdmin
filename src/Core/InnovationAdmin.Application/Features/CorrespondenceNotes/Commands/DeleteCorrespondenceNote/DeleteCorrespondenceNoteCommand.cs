using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.CorrespondenceNotes.Commands.DeleteCorrespondenceNote
{
    public class DeleteCorrespondenceNoteCommand : IRequest<Response<bool>>
    {
        public Guid Id { get; set; }

    }
}

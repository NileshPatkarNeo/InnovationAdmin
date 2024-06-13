using InnovationAdmin.Application.Features.RemittanceType.Commands.CreateRemittanceType;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.CorrespondenceNotes.Commands.CreateCorrespondenceNote
{
    public class CreateCorrespondenceNoteCommand : IRequest<Response<CreateCorrespondenceNoteDto>>
    {
        public string Note { get; set; }
    }
}

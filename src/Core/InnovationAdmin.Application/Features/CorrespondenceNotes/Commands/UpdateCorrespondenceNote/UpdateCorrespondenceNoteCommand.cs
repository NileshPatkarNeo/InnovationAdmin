using InnovationAdmin.Application.Features.RemittanceType.Commands.UpdateRemittanceType;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.CorrespondenceNotes.Commands.UpdateCorrespondenceNote
{
    public class UpdateCorrespondenceNoteCommand : IRequest<Response<UpdateCorrespondenceNoteDto>>
    {
        public Guid Id { get; set; }
        public string Note { get; set; }
    }
}

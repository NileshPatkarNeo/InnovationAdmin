using InnovationAdmin.Application.Features.CorrespondenceNotes.Queries.GetCorrespondenceNoteQuery;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.CorrespondenceNotes.Queries.GetAllListCorrespondenceNoteQuery
{
    public class GetAllCorrespondenceNoteQuery : IRequest<Response<IEnumerable<CorrespondenceNoteDto>>>
    {

    }
}

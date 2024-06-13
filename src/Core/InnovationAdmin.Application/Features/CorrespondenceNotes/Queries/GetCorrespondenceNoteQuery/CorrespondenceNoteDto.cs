using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.CorrespondenceNotes.Queries.GetCorrespondenceNoteQuery
{
    public class CorrespondenceNoteDto
    {
        public Guid Id { get; set; }
        public string Note { get; set; }
    }
}

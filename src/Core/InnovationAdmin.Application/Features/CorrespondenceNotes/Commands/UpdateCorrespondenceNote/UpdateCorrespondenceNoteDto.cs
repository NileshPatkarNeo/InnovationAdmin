using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.CorrespondenceNotes.Commands.UpdateCorrespondenceNote
{
    public class UpdateCorrespondenceNoteDto
    {
        public Guid Id { get; set; }
        public string Note { get; set; }
    }
}

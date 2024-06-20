using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.CorrespondenceNotes.Commands.CreateCorrespondenceNote
{
    public class CreateCorrespondenceNoteDto
    {
        public Guid ID { get; set; }

        public string Note { get; set; }
    }
}

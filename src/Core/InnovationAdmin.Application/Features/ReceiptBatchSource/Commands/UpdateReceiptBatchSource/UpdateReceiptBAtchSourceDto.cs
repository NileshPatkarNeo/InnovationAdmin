using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.ReceiptBatchSource.Commands.UpdateReceiptBatchSource
{
    public class UpdateReceiptBAtchSourceDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }
    }
}

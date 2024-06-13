using System;

namespace InnovationAdmin.Application.Features.Template.Queries.GetTemplatesList
{
    public class TemplateListVM
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string PdfTemplateFile { get; set; }
        public string Domain { get; set; }
        public string Size { get; set; }
    }
}

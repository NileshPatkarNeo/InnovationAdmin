namespace InnovationAdmin.Application.Features.Template.Commands.UpdateTemplate
{
    public class UpdateTemplateDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string PdfTemplateFile { get; set; }
        public string Domain { get; set; }
        public string Size { get; set; }
    }
}

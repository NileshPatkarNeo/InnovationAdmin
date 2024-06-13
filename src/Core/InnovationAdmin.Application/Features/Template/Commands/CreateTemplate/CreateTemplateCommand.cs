using InnovationAdmin.Application.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace InnovationAdmin.Application.Features.Template.Commands.CreateTemplate
{
    public class CreateTemplateCommand : IRequest<Response<CreateTemplateDto>>
    {
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name should have at least 2 characters and a maximum of 50.")]
        public string Name { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "PdfTemplateFile length can't be more than 200.")]
        public string PdfTemplateFile { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Domain length can't be more than 50.")]
        public string Domain { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Size length can't be more than 50.")]
        public string Size { get; set; }
    }
}

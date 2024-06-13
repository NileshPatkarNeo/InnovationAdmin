using InnovationAdmin.Application.Features.DataSources.Commands.UpdateDataSource;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.BillingMethodTypes.Commands.UpdateBillingMethodType
{
    public class UpdateBillingMethodTypeCommand : IRequest<Response<UpdateBillingMethodTypeCommandDto>>
    {
        public Guid ID { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        [MinLength(2, ErrorMessage = "Name should have at least 2 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]*$", ErrorMessage = "Name can only contain alphanumeric characters and spaces.")]
        public string Name { get; set; }
    }
}

﻿using InnovationAdmin.Application.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;


namespace InnovationAdmin.Application.Features.BillingMethodTypes.Commands.CreateBillingMethodType
{
    public class CreateBillingMethodTypeCommand : IRequest<Response<CreateBillingMethodTypeDto>>
    {
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        [MinLength(2, ErrorMessage = "Name should have at least 2 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]*$", ErrorMessage = "Name can only contain alphanumeric characters and spaces.")]
        public string Name { get; set; }
    }
}

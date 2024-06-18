using InnovationAdmin.Application.Features.ContractTerms.Commands.CreateContractTerm;
using InnovationAdmin.Application.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace InnovationAdmin.Application.Features.ContractTerms.Commands.CreateContractTerm
{
    public class CreateContractTermCommand : IRequest<Response<CreateContractTermDto>>
    {
        [Required]
        [MaxLength(100)]
        [MinLength(2, ErrorMessage = "Name should have at least 2 characters.")]
        [StringLength(100, ErrorMessage = "Name length can't be more than 100.")]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(2, ErrorMessage = "ContractType should have at least 2 characters.")]
        [StringLength(50, ErrorMessage = "ContractType length can't be more than 50.")]
        public string ContractType { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "ContractTypeCode should be a positive integer.")]
        public int ContractTypeCode { get; set; }
    }
}

using Innovation_Admin.UI.Models.ResponsesModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Innovation_Admin.UI.Models.ContractTerms
{
    public class ContractTermDto
    {
        [JsonProperty("id")]
        public Guid ID { get; set; }

        [JsonProperty("name")]
        [Required(ErrorMessage = "Name is required.")]
        [RegularExpression(@"^[a-zA-Z]+(\s[a-zA-Z]+)*$", ErrorMessage = "Name can only contain characters.")]
        [MinLength(2, ErrorMessage = "Name should be at least 2 characters.")]
        [Remote(action: "IsContractTermNameUnique", controller: "Common", AdditionalFields = "__RequestVerificationToken," + nameof(ID),
                ErrorMessage = "Name is already in use.")]
        [StringLength(100, ErrorMessage = "Name length cannot exceed 100 characters.")]
        public string Name { get; set; }

        [JsonProperty("contractType")]
        [Required(ErrorMessage = "Contract Type is required.")]
        [RegularExpression(@"^[a-zA-Z]+(\s[a-zA-Z]+)*$", ErrorMessage = "Contract Type can only contain characters.")]
        [MinLength(2, ErrorMessage = "Contract Type should be at least 2 characters.")]
        [StringLength(50, ErrorMessage = "Contract Type length cannot exceed 50 characters.")]
        public string ContractType { get; set; }

        [JsonProperty("contractTypeCode")]
        [Required(ErrorMessage = "Contract Type Code is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Contract Type Code should be a positive integer.")]
        public int ContractTypeCode { get; set; }

        [JsonProperty("status")]
        public bool Status { get; set; }
    }
}

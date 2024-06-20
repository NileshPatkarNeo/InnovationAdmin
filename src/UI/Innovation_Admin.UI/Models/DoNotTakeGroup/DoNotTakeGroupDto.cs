using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Innovation_Admin.UI.Models.DoNotTakeGroup
{
    public class DoNotTakeGroupDto
    {

        [JsonProperty("id")]
        public Guid Id { get; set; }

        
        [JsonProperty("groupCode")]
        [Required]
        [DisplayName("Group Code")]
        public int GroupCode { get; set; }

      

        [JsonProperty("groupName")]
        [Required]
        [DisplayName("Group Name")]
        public string GroupName { get; set; }

      
    }
}

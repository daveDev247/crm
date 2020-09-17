using System.ComponentModel.DataAnnotations;

namespace FintrakERPIMSDemo.Localization.Dto
{
    public class CreateOrUpdateLanguageInput
    {
        [Required]
        public ApplicationLanguageEditDto Language { get; set; }
    }
}
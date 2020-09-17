using System.ComponentModel.DataAnnotations;

namespace FintrakERPIMSDemo.Authorization.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}

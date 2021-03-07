using System.ComponentModel.DataAnnotations;

namespace Tyranids.MvcUi.Models
{
    public class UserModel
    {
        [Display(Name = "Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "{0}'s format should be valid")]
        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "{0}'s length should be between {2} and {1} characters.")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "{0}'s length should be between {2} and {1} characters.")]
        public string Password { get; set; }
    }
}
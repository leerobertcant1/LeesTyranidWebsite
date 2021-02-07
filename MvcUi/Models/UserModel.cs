using System.ComponentModel.DataAnnotations;

namespace Tyranids.MvcUi.Models
{
    public class UserModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "{0}'s length should be between {2} and {1}.")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "{0}'s length should be between {2} and {1}.")]
        public string Password { get; set; }
    }
}
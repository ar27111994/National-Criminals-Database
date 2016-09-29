using System.ComponentModel.DataAnnotations;

namespace WebUIClient.ViewModels
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

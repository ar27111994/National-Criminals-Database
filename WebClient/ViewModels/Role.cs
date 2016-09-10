using System.ComponentModel.DataAnnotations;

namespace WebUIClient.ViewModels
{
    public class Role
    {
        public byte Id { get; set; }
        [Required]
        [StringLength(50,MinimumLength =2)]
        [Display(Name ="Role Name")]
        public string RoleName { get; set; }
    }
}
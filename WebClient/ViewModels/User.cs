using System;
using System.ComponentModel.DataAnnotations;

namespace WebUIClient.ViewModels
{
    public class User
    {
        public long Id { get; set; }
        [Required]
        [StringLength(50,MinimumLength =2)]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(50,MinimumLength =2)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public DateTime LastLogin { get; set; }
        [Required]
        public byte RoleId { get; set; }
        public Role Role { get; set; }
    }
}

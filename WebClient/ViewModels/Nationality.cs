using System.ComponentModel.DataAnnotations;

namespace WebUIClient.ViewModels
{
    public class Nationality
    {
        public byte Id { get; set; }
        [Required]
        [Display(Name ="Nationality")]
        public string NationalityName { get; set; }

    }
}
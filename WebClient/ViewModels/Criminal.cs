using System.ComponentModel.DataAnnotations;

namespace WebUIClient.ViewModels
{
    public class Criminal
    {
        public enum Gender { Male = 'M', Female = 'F', Other = 'T' }
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EnumDataType(typeof(Gender), ErrorMessage = "Required Field")]
        public Gender gender { get; set; }
        public char Sex { get; set; }

        [Required]
        public byte NationalityID { get; set; }
        public Nationality Nationality { get; set; }
        [Required]
        [Range(3.0,12.0)]
        public double? HieghtMin { get; set; }
        [Required]
        [Range(3.0, 12.0)]
        public double? HieghtMax { get; set; }

        public int? WeightMin { get; set; }

        public int? WeightMax { get; set; }
        [Range(10, 120)]
        [Required]
        public int? AgeMin { get; set; }
        [Range(10, 120)]
        [Required]
        public int? AgeMax { get; set; }

    }
}
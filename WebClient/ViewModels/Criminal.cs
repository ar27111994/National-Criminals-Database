using System.ComponentModel.DataAnnotations;

namespace WebUIClient.ViewModels
{
    public class Criminal
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(1)]
        public string Sex { get; set; }
        [Required]
        public byte NationalityID { get; set; }
        public Nationality Nationality { get; set; }
        [Range(3.0,12.0)]
        public double? HieghtMin { get; set; }
        [Range(3.0, 12.0)]
        public double? HieghtMax { get; set; }

        public int? WeightMin { get; set; }

        public int? WeightMax { get; set; }
        [Range(10, 120)]
        public int? AgeMin { get; set; }
        [Range(10, 120)]
        public int? AgeMax { get; set; }

    }
}
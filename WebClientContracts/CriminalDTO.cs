using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System.Runtime.Serialization;

namespace WebClientContracts
{
    [DataContract(Name ="Criminal")]
    public class CriminalDTO
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        [NotNullValidator]
        public string Name { get; set; }
        [DataMember]
        [NotNullValidator]
        [DomainValidator("M", "F", "T")]
        public string Sex { get; set; }
        [DataMember]
        [NotNullValidator]
        public byte NationalityID { get; set; }
        [DataMember]
        public NationalityDTO Nationality { get; set; }
        [DataMember]
        [RangeValidator(3.0,RangeBoundaryType.Inclusive,12.0, RangeBoundaryType.Inclusive)]
        public double? HieghtMin { get; set; }
        [DataMember]
        [RangeValidator(3.0, RangeBoundaryType.Inclusive, 12.0, RangeBoundaryType.Inclusive)]
        public double? HieghtMax { get; set; }
        [DataMember]
        public int? WeightMin { get; set; }
        [DataMember]
        public int? WeightMax { get; set; }
        [DataMember]
        [RangeValidator(10, RangeBoundaryType.Inclusive, 120, RangeBoundaryType.Inclusive)]
        public int? AgeMin { get; set; }
        [DataMember]
        [RangeValidator(10, RangeBoundaryType.Inclusive, 120, RangeBoundaryType.Inclusive)]
        public int? AgeMax { get; set; }

    }
}

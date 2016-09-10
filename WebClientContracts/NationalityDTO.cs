using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace WebClientContracts
{
    [DataContract(Name ="Nationality")]
    public class NationalityDTO
    {
        [DataMember]
        public byte Id { get; set; }
        [NotNullValidator]
        [DataMember]
        public string NationalityName { get; set; }
    }
}
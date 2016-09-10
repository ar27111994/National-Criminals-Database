using System.Runtime.Serialization;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;


namespace WebClientContracts
{
    [DataContract(Name ="Role")]
    public class RoleDTO
    {
        [DataMember]
        public byte Id { get; set; }
        [DataMember]
        [NotNullValidator]
        [StringLengthValidator(50)]
        public string RoleName { get; set; }
    }
}
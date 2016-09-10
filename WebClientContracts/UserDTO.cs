using System;
using System.Runtime.Serialization;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;


namespace WebClientContracts
{
    [DataContract(Name ="User")]
    [KnownType(typeof(RoleDTO))]
    public class UserDTO
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        [NotNullValidator]
        [StringLengthValidator(2,50)]
        public string Username { get; set; }
        [DataMember]
        [NotNullValidator]
        [StringLengthValidator(2, 50)]
        public string Password { get; set; }
        [DataMember]
        [NotNullValidator]
        public string Email { get; set; }
        [DataMember]
        [NotNullValidator]
        public DateTime LastLogin { get; set; }
        [DataMember]
        [NotNullValidator]
        public byte RoleId { get; set; }
        [DataMember]
        public RoleDTO Role { get; set; }

    }
}

using System.ServiceModel;
using WebClientContracts;
using System.ServiceModel.Web;
using Microsoft.Practices.EnterpriseLibrary.Validation.Integration.WCF;
using System;

namespace BusinessServices
{
    [ServiceContract]
    [ValidationBehavior]
    public interface IUserService:IDisposable
    {
        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        [WebInvoke(UriTemplate = "/auth-api/", Method = "POST", BodyStyle =WebMessageBodyStyle.Wrapped)]
        bool Authenticate(string password, string email);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        [WebInvoke(UriTemplate = "", Method = "POST")]
        void Register(UserDTO user);
    }

}

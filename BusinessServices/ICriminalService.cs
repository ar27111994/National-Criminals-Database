using Microsoft.Practices.EnterpriseLibrary.Validation.Integration.WCF;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using WebClientContracts;

namespace BusinessServices
{
    [ServiceContract]
    public interface ICriminalService:IDisposable
    {
        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        [WebInvoke(UriTemplate = "", Method = "POST")]
        void Create(CriminalDTO criminal);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        [WebGet(UriTemplate = "")]

        IEnumerable<CriminalDTO> GetCriminals();

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        [WebInvoke(UriTemplate = "/search", BodyStyle =WebMessageBodyStyle.Wrapped, Method ="POST")]

        bool SearchCriminals(CriminalDTO criminal, string[] emails);
        void SendCriminalRecords(IEnumerable<Criminal> criminals, string[] emails);
    }
}

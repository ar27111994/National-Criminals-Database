using Microsoft.Practices.EnterpriseLibrary.Validation.Integration.WCF;
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
    [ValidationBehavior]

    public interface INationalityService : IDisposable
    {
        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        [WebInvoke(UriTemplate = "", Method = "POST")]
        void Create(NationalityDTO Nationality);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        [WebGet(UriTemplate = "")]

        IEnumerable<NationalityDTO> GetNationalities();
    }
}

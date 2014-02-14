using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF_Synthese
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServiceWCF_Synthese
    {

        [OperationContract]
        [WebInvoke(UriTemplate="jambon/{id}", BodyStyle=WebMessageBodyStyle.WrappedRequest,  ResponseFormat=WebMessageFormat.Xml)]
        UsagerWCF GetUsager(int pID);
                
    }

}

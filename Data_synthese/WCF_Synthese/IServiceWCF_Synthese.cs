using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF_Synthese.EntitesWCF;

namespace WCF_Synthese
{
   
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IServiceWCF_Synthese
    {

        [OperationContract]
        [WebInvoke(Method = "GET",
            BodyStyle = WebMessageBodyStyle.Wrapped,
           // RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GetUsager/{pID}")]
        UsagerWCF GetUsager(string pID);
                
        [OperationContract]
        string HelloWorld();

        
        [OperationContract(IsInitiating = true, IsTerminating = false)]
        void Login(string user, string password);

        [OperationContract(IsInitiating = false, IsTerminating = true)]
        void Logout();
    }

}

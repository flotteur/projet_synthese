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
   
   // [ServiceContract(SessionMode = SessionMode.Required)]
    [ServiceContract]
    public interface IServiceWCF_Synthese
    {

        [OperationContract]
        [WebInvoke(Method = "GET",
            BodyStyle = WebMessageBodyStyle.Wrapped,
           // RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GetUsager/{pID}")]
        UsagerWCF GetUsager(string pID);
        
        [WebGet() ]
        [OperationContract]
        string HelloWorld();

        
        //[OperationContract(IsInitiating = true, IsTerminating = false)]
        //[OperationContract]
        //void Login(string user, string password);

        ////[OperationContract(IsInitiating = false, IsTerminating = true)]
        //[OperationContract]
        //void Logout();
    }

}

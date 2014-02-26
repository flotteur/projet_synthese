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
   
    [ServiceContract]
    public interface IServiceWCF_Synthese
    {

        /*[OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped,
           // RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GetUsager/{pID}")]
        UsagerWCF GetUsager(string pID);*/
        /*       
        [OperationContract]
        [WebInvoke(Method="PUT",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "observation/{id}")]
        string AddObservation();

        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "observation/{id}")]
        Observation GetObservation(int id);

        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "getListObservation")]
        ListeObservation GetListeObservation();*/


        /*
        [OperationContract]
        void Login(string user, string password);

        [OperationContract]
        void Logout();*/
    }

}

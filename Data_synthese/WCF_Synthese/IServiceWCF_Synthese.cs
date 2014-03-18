using BO_Synthese;
using System;
using System.Collections.Generic;
using System.IO;
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
               
        [OperationContract]
        [WebInvoke(Method="POST",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "observation")]
        void AddObservation(ObservationDTO observation);
        
        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "observation/{id}")]
        ObservationDTO GetObservation(string id);

        [OperationContract]
        [WebGet(UriTemplate = "image/{id}")]
        Stream GetImage(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "image/{id}/{filename}")]
        void AddImage(string id, string filename, Stream file);

        //[OperationContract]
        //[WebGet(BodyStyle = WebMessageBodyStyle.Wrapped,
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    UriTemplate = "getListObservation")]
        //ListeObservationWCF GetListeObservation();


        //[OperationContract(IsInitiating = true, IsTerminating = false)]
        //[OperationContract]
        //void Login(string user, string password);

        //[OperationContract]
        //void Logout();*/
        //void Logout();
    }

}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using WCF_Synthese.EntitesWCF;
using BO_Synthese;
using System.IO;

namespace WCF_Synthese
{
   
  // [ServiceContract(SessionMode = SessionMode.Required)]
    [ServiceContract]
    
    public interface IServiceWCF_Synthese
    {

        [OperationContract]
        [WebInvoke(Method = "GET",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GetUsager/{pID}")]
        UsagerWCF GetUsager(string pID);

        [OperationContract]
        [WebInvoke(Method = "*",
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "InsertUsager")]
        UsagerWCF InsertUsager(UsagerWCF pUsager);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "UpdatetUsager/")]
        UsagerWCF UpdateUsager(UsagerWCF pUsager);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "DeleteUsager/{pID}")]
        string DeleteUsager(string pID);

     // [OperationContract(IsInitiating = true, IsTerminating = false)]
        [OperationContract]
        [WebInvoke(Method = "GET",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "Login/{user}/{password}")]
        UsagerWCF Login(string user, string password);

      //  [OperationContract(IsInitiating = false, IsTerminating = true)]
        [OperationContract]
        [WebInvoke(Method = "GET",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "Logout")]
        void Logout();
		
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
    }

}
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
using BO_Synthese.DTO;

namespace WCF_Synthese
{
   
  // [ServiceContract(SessionMode = SessionMode.Required)]
    [ServiceContract]
    
    public interface IServiceWCF_Synthese
    {

        #region " Usager "
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

#endregion

        #region " Oiseau "
        [OperationContract]
        [WebInvoke(Method = "GET",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GetOiseau/{pID}")]
        OiseauWCF GetOiseau(string pID);

        [OperationContract]
        [WebInvoke(Method = "*",
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "InsertOiseau")]
        OiseauWCF InsertOiseau(OiseauWCF pOiseau);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "UpdatetOiseau/")]
        OiseauWCF UpdateOiseau(OiseauWCF pOiseau);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "DeleteOiseau/{pID}")]
        string DeleteOiseau(string pID);

#endregion

        #region " CriOiseau "
        [OperationContract]
        [WebInvoke(Method = "GET",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GetCriOiseau/{pID}")]
        CriOiseauWCF GetCriOiseau(string pID);

        [OperationContract]
        [WebInvoke(Method = "*",
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "InsertCriOiseau")]
        CriOiseauWCF InsertCriOiseau(CriOiseauWCF pOiseau);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "UpdateCriOiseau/")]
        CriOiseauWCF UpdateCriOiseau(CriOiseauWCF pCriOiseau);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "DeleteCriOiseau/{pID}")]
        string DeleteCriOiseau(string pID);

#endregion

        #region " Photo "
        [OperationContract]
        [WebInvoke(Method = "GET",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GetPhoto/{pID}")]
        PhotoWCF GetPhoto(string pID);

        [OperationContract]
        [WebInvoke(Method = "*",
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "InsertPhoto")]
        PhotoWCF InsertPhoto(PhotoWCF pOiseau);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "UpdatePhoto/")]
        PhotoWCF UpdatePhoto(PhotoWCF pPhoto);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "DeletePhoto/{pID}")]
        string DeletePhoto(string pID);

        #endregion


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
            BodyStyle = WebMessageBodyStyle.Bare,
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
        [WebGet(BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "observation")]
        List<ObservationDTO> GetAllObservation();

        [OperationContract]
        [WebGet(UriTemplate = "image/{id}")]
        Stream GetImage(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "image/{id}/{filename}")]
        void AddImage(string id, string filename, byte[] file);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, 
            UriTemplate = "commentaire/{id}")]
        void DeleteCommentaire(string id);

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "commentaire")]
        CommentaireDTO AddCommentaire(CommentaireDTO commentaire);

        [OperationContract]
        [WebInvoke(Method = "GET",
            UriTemplate = "commentaire/{id}",
            ResponseFormat = WebMessageFormat.Json)]
        List<CommentaireDTO> GetCommentaire(string id);

		
		//[OperationContract]
        //[WebGet(BodyStyle = WebMessageBodyStyle.Wrapped,
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    UriTemplate = "getListObservation")]
        //ListeObservationWCF GetListeObservation();
    }

}
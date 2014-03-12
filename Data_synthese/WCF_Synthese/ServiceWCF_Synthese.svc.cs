﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
//using System.ServiceModel;
using BO_Synthese;
using Entites_Synthese;
using WCF_Synthese.EntitesWCF;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace WCF_Synthese
{
         [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class ServiceWCF_Synthese : IServiceWCF_Synthese
    {

        private BO aBusinessObject;
        public BO BusinessObject
        {
            get
            {
                if (aBusinessObject == null)
                    aBusinessObject = new BO();
                return aBusinessObject;
            }
        }

        public string HelloWorld()
        {
            return "Hello";
        }

        
        public void Logout()
        {
            BusinessObject.LogOut();
        }


        public UsagerWCF InsertUsager(UsagerWCF pUsager)
        {
            if (WebOperationContext.Current.IncomingRequest.Method == "OPTIONS")
            {
                WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "*");
                WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Methods", "POST");
                WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Accept");

                return null;
            }
            UsagerWCF retour = null;

            Usager_Entite usager = pUsager.Convertir();

            usager = BusinessObject.CreerUsager(usager);

            if (usager != null)
            {
                retour = new UsagerWCF();

                retour.Nom = usager.Nom;
                retour.Courriel = usager.Courriel;
                retour.EstAdministrateur = usager.EstAdministrateur;
                retour.ID = usager.ID;
                retour.MotDePasse = usager.MotDePasse;
                retour.NomUsager = usager.NomUsager;
                retour.MessageErreur = usager.MessageErreur;
                if (String.IsNullOrEmpty(usager.MessageErreur))
                    BusinessObject.SaveChanges();
            }

            return retour;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pID"></param>
        /// <returns></returns>
        public UsagerWCF GetUsager(string pID)
        {

            BO BusinessObject = new BO();
            UsagerWCF retour = null;

            Usager_Entite usager = BusinessObject.Getusager(int.Parse(pID));

            if (usager != null)
            {
                retour = new UsagerWCF();

                retour.Nom = usager.Nom;
                retour.Courriel = usager.Courriel;
                retour.EstAdministrateur = usager.EstAdministrateur;
                retour.ID = usager.ID;
                retour.MotDePasse = string.Empty ;
                retour.NomUsager = usager.NomUsager;
            }

            return retour;
        }


        public string  DeleteUsager(string pID)
        {
            if (BusinessObject.SupprimerUsager(int.Parse(pID)))
                return BusinessObject.MessageErreur;

            return "";

        }

        public UsagerWCF UpdateUsager(UsagerWCF pUsager)
        {
            Usager_Entite usager = pUsager.Convertir();
            usager=  BusinessObject.UpdateUsager(usager );
            if (string.IsNullOrEmpty( usager.MessageErreur))
                BusinessObject.SaveChanges();
            return pUsager.Convertir( usager);
        }

        public UsagerWCF Login(string pUserName, string pPassword){
        
            UsagerWCF retour = new UsagerWCF();

            Usager_Entite usager = BusinessObject.Login(pUserName,
                pPassword); 

            return  retour.Convertir(usager);
        }
    }
}

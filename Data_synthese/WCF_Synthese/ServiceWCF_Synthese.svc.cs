using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
//using System.ServiceModel;
using BO_Synthese;
using Entites_Synthese;
using WCF_Synthese.EntitesWCF;

namespace WCF_Synthese
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    
    public class ServiceWCF_Synthese : IServiceWCF_Synthese
    {

        private BO aBusinessObject;
        public BO BusinessObject{ 
            get {
                if (aBusinessObject==null)
                    aBusinessObject = new BO();
                return aBusinessObject;
            } 
        }

        public string HelloWorld()
        {
            return "Hello";
        }

        public UsagerWCF GetUsager(string pID)
        {
            // test
           // Thread.CurrentPrincipal = HttpContext.Current.User;


            BO BusinessObject = new BO();
            UsagerWCF retour = null;
           
            Usager_Entite usager = BusinessObject.Getusager(int.Parse(pID));

            if (usager != null)
            {
                retour = new UsagerWCF();

                retour.Nom = usager.Nom;
                retour.Courriel = usager.Courriel;
                retour.EstAdministrateur = usager.EstAdministrateur;
                retour.Hash = usager.Hash;
                retour.ID = usager.ID;
                retour.MotDePasse = usager.MotDePasse;
                retour.NomUsager = usager.NomUsager;
            }
           
           return retour ;
        }



        public void Login(string user, string password)
        {
            //BusinessObject.login;
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }
    }
}

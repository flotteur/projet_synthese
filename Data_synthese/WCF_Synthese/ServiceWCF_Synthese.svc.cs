using System;
using System.Collections.Generic;
using System.Linq;
using BO_Synthese;
using Entites_Synthese;     
using WCF_Synthese.EntitesWCF;
using BO_Synthese;
using Data_synthese;

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

        public Observation AddObservation(ObservationWCF observation)
        {
            Observation tewer = new Observation();
            tewer.Id = 1;
            tewer.IDUsager = 1;
            tewer.IDOiseau = 1;
            ObservationRepository test = new ObservationRepository();
            test.createObservation(tewer);
        }
        /*
        public UsagerWCF GetUsager(string pID)
        {
            BO BusinessObject = new BO();
            UsagerWCF retour = null;

            Usager_Entite usager = BusinessObject.Getusager(int.Parse(pID));

            if (usager != null)
            {
                retour = new UsagerWCF();

                retour.Courriel = usager.Courriel;
                retour.EstAdministrateur = usager.EstAdministrateur;
                retour.Hash = usager.Hash;
                retour.ID = usager.ID;
                retour.MotDePasse = usager.MotDePasse;
                retour.NomUsager = usager.MotDePasse;
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
        }*/
    }
}

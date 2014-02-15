using System;
using System.Collections.Generic;
using System.Linq;
using BO_Synthese;
using Entites_Synthese;

namespace WCF_Synthese
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class ServiceWCF_Synthese : IServiceWCF_Synthese
    {

        public string HelloWorld()
        {
            return "Hello";
        }

        public UsagerWCF GetUsager(string pID)
        {
            BO BusinessObject = new BO();
            UsagerWCF retour = null;

           //// Usager_Entite usager = BusinessObject.Getusager(pID);

           // if (usager != null)
           // {
           //     retour = new UsagerWCF();

           //     retour.Courriel = usager.Courriel;
           //     retour.EstAdministrateur = usager.EstAdministrateur;
           //     retour.Hash = usager.Hash;
           //     retour.ID = usager.ID;
           //     retour.MotDePasse = usager.MotDePasse;
           //     retour.NomUsager = usager.MotDePasse;
           // }

            retour = new UsagerWCF() ;
            retour.Courriel = "Courriel";
            return retour;
        }
             
    }
}

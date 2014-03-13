using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
//using System.ServiceModel;
using BO_Synthese;
using Entites_Synthese;
using WCF_Synthese.EntitesWCF;
using System.IO;

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

        /// <summary>
        /// Ce service permet de créer un nouvelle observation
        /// </summary>
        /// <param name="observation">L'observation à ajouter</param>
        public void AddObservation(ObservationDTO observation)
        { 
            ObservationRepository repository = new ObservationRepository(observation);
            repository.createObservation();
        }

        /// <summary>
        /// Ce service permet d'obtenir le détail d'une observation à partir du ID
        /// </summary>
        /// <param name="id">Le id de l'observation</param>
        /// <returns>L'observation</returns>
        public ObservationDTO GetObservation(string id)
        {
            ObservationRepository repository = new ObservationRepository();
            int numericId;
            Int32.TryParse(id, out numericId);
            return repository.GetObservationFromId(numericId);
        }

        public Stream GetImage(string id)
        {
            PhotoObservationRepository repository = new PhotoObservationRepository();
            int numericId;
            Int32.TryParse(id, out numericId);

            Stream stream = new MemoryStream(repository.GetPhotoObservationFromId(numericId).Image);
            return stream;
        }
        /*
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
        }*/
    }
}

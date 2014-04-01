using System;
using System.Collections.Generic;
using System.Linq;
using BO_Synthese;
using Entites_Synthese;
using WCF_Synthese.EntitesWCF;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.IO;
using BO_Synthese.DTO;
using BO_Synthese.Repository;

namespace WCF_Synthese
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class ServiceWCF_Synthese : IServiceWCF_Synthese, IDisposable
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
        
        public void Logout()
        {
            BusinessObject.LogOut();
        }

        /// <summary>
        /// Ce service permet de créer un nouvelle observation
        /// </summary>
        /// <param name="observation">L'observation à ajouter</param>
        public void AddObservation(ObservationDTO observation)
        { 
            using (var repository = new ObservationRepository(observation)) {
                repository.createObservation();
            }
        }

        /// <summary>
        /// Ce service permet d'obtenir le détail d'une observation à partir du ID
        /// </summary>
        /// <param name="id">Le id de l'observation</param>
        /// <returns>L'observation</returns>
        public ObservationDTO GetObservation(string id)
        {
            using (var repository = new ObservationRepository()) {
                int numericId;
                Int32.TryParse(id, out numericId);
                return repository.GetObservationFromId(numericId);
            }
        }
        
        /// <summary>
        /// Ce service permet d'obtenir la liste des observations
        /// </summary>
        /// <returns>La liste de toutes les observations</returns>
        public List<ObservationDTO> GetAllObservation()
        {
            using (var repository = new ObservationRepository()) {
                return repository.GetAllObservation();
            }
        }

        /// <summary>
        /// Permet la supression d'une observation
        /// </summary>
        public void DeleteObservation(string id)
        {
            using (var repository = new ObservationRepository())
            {
                int numericId;
                Int32.TryParse(id, out numericId);
                repository.DeleteObservation(numericId);
            }
        }

        /// <summary>
        /// Ce service permet d'obtenir une photo d'observation en fonction du ID de la photo
        /// </summary>
        /// <param name="id">Id de l'image</param>
        /// <param name="type">Type de l'image</param>
        /// <returns></returns>
        public Stream GetImage(string type, string id)
        {
            
            int numericId;
            Int32.TryParse(id, out numericId);
            var repository = new PhotoRepository(type, numericId);

            return new MemoryStream(repository.GetPhoto());
        }

        public void AddImage(string id, string filename, byte[] stream)
        {
            //using (var repository = new PhotoRepository()) {
            //
            //    Stream file = new MemoryStream(stream);
            //    int numericId;
            //    Int32.TryParse(id, out numericId);
            //    repository.CreatePhotoObservation(id, filename, file);
            //}

        }

        #region " Usager "
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

            Usager_Entite usager = (Usager_Entite ) pUsager.Convertir();

            usager = BusinessObject.CreerUsager(usager);

            if (usager != null)
            {
                retour = new UsagerWCF();
                retour.Convertir(usager);
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
                retour.Convertir(usager);
            }

            return retour;
        }
             
        public string  DeleteUsager(string pID)
        {
            if (BusinessObject.SupprimerUsager(int.Parse(pID)))
                return BusinessObject.MessageErreur;
            else
                BusinessObject.SaveChanges();
            return "";

        }

        public UsagerWCF UpdateUsager(UsagerWCF pUsager)
        {
            Usager_Entite usager =(Usager_Entite)pUsager.Convertir();
            usager=  BusinessObject.UpdateUsager(usager );
            if (string.IsNullOrEmpty( usager.MessageErreur))
                BusinessObject.SaveChanges();
            pUsager.Convertir(usager);
            return pUsager;
        }
        #endregion 

        #region " Oiseau "

        public OiseauWCF InsertOiseau(OiseauWCF pOiseau)
        {
            if (WebOperationContext.Current.IncomingRequest.Method == "OPTIONS")
            {
                WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "*");
                WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Methods", "POST");
                WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Accept");

                return null;
            }
            OiseauWCF retour = null;

            Oiseau_Entite Oiseau = (Oiseau_Entite) pOiseau.Convertir();

            Oiseau = BusinessObject.CreerOiseau(Oiseau);

            if (Oiseau != null)
            {
                retour = new OiseauWCF();
                CriOiseauWCF criWCF;
                retour.ID = Oiseau.ID;
                
                retour.Description = Oiseau.Description;
                retour.Espece= Oiseau.Espece;
                // la liste des cris d'oiseau
                foreach (CriOiseau_Entite cri in Oiseau.CrisOiseau)
	            {
                    criWCF = new CriOiseauWCF();
                    criWCF.Convertir(cri);
                    retour.CrisOiseau.Add(criWCF); 
	            }  

                // La liste des photos
                PhotoWCF photoWCF;
                foreach( Photo_Entite photo in Oiseau.Photos){
                
                    photoWCF = new PhotoWCF();
                    photoWCF.Convertir(photo);
                    retour.Photos.Add(photoWCF);
                }
                                
                retour.MessageErreur = Oiseau.MessageErreur;
                if (String.IsNullOrEmpty(Oiseau.MessageErreur))
                    BusinessObject.SaveChanges();
            }

            return retour;
        }


        public OiseauWCFList GetAllOiseaux(string pStart, string  pQty) {

            
            OiseauxList_Entite oiseauxListe = BusinessObject.GetOiseaux(Convert.ToInt32( pQty),
                Convert.ToInt32(pStart));
            OiseauWCFList retour = new OiseauWCFList();
            retour.Convertir(oiseauxListe);

            return retour;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pID"></param>
        /// <returns></returns>
        public OiseauWCF GetOiseau(string pID)
        {

            OiseauWCF retour = null;

            Oiseau_Entite Oiseau = BusinessObject.GetOiseau(int.Parse(pID));

            if (Oiseau != null)
            {
                retour = new OiseauWCF();
                retour.Convertir(Oiseau);
                
            }

            return retour;
        }

        public string DeleteOiseau(string pID)
        {
            if (BusinessObject.SupprimerOiseau(int.Parse(pID)))
                return BusinessObject.MessageErreur;

            return "";

        }

        public OiseauWCF UpdateOiseau(OiseauWCF pOiseau)
        {
            Oiseau_Entite Oiseau = (Oiseau_Entite)pOiseau.Convertir();
            Oiseau = BusinessObject.UpdateOiseau(Oiseau);
            if (string.IsNullOrEmpty(Oiseau.MessageErreur))
                BusinessObject.SaveChanges();
            pOiseau.Convertir(Oiseau);
            return pOiseau;
        }

        public void DeleteCommentaire(string id)
        {
            using(var repository = new CommentaireRepository())
            {
                int numericId;
                Int32.TryParse(id, out numericId);

                repository.DeleteCommentaire(numericId);
            }
        }

        public CommentaireDTO AddCommentaire(CommentaireDTO commentaire)
        {
            using (var repository = new CommentaireRepository())
            {
                return repository.AddCommentaire(commentaire);
            }
        }

        public List<CommentaireDTO> GetCommentaire(string id) 
        {
            using (var repository = new CommentaireRepository())
            {
                int numericId;
                Int32.TryParse(id, out numericId);

                return repository.GetListCommentaire(numericId);
            }
        }
        #endregion


        #region " CriOiseau "

        public CriOiseauWCF InsertCriOiseau(CriOiseauWCF pCriOiseau)
        {
            CriOiseauWCF retour = null;

            CriOiseau_Entite CriOiseau = (CriOiseau_Entite)pCriOiseau.Convertir();

            CriOiseau = BusinessObject.CreerCriOiseau(CriOiseau);

            if (CriOiseau != null)
            {
                retour = new CriOiseauWCF();
                retour.Convertir(CriOiseau);
                
                if (String.IsNullOrEmpty(CriOiseau.MessageErreur))
                    BusinessObject.SaveChanges();
            }

            return retour;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pID"></param>
        /// <returns></returns>
        public CriOiseauWCF GetCriOiseau(string pID)
        {

            BO BusinessObject = new BO();
            CriOiseauWCF retour = null;

            CriOiseau_Entite CriOiseau = BusinessObject.GetCriOiseau(int.Parse(pID));

            if (CriOiseau != null)
            {
                retour = new CriOiseauWCF();
                retour.Convertir(CriOiseau);

            }

            return retour;
        }

        public string DeleteCriOiseau(string pID)
        {
            if (BusinessObject.SupprimerCriOiseau(int.Parse(pID)))
                return BusinessObject.MessageErreur;

            return "";

        }

        public CriOiseauWCF UpdateCriOiseau(CriOiseauWCF pCriOiseau)
        {
            CriOiseau_Entite CriOiseau = (CriOiseau_Entite)pCriOiseau.Convertir();
            CriOiseau = BusinessObject.UpdateCriOiseau(CriOiseau);
            if (string.IsNullOrEmpty(CriOiseau.MessageErreur))
                BusinessObject.SaveChanges();
            pCriOiseau.Convertir(CriOiseau);
            return pCriOiseau;
        }


        #endregion


        #region " Photo "

        public PhotoWCF InsertPhoto(PhotoWCF pPhoto)
        {
           
            PhotoWCF retour = null;
            Photo_Entite Photo = (Photo_Entite)pPhoto.Convertir();
            Photo = BusinessObject.CreerPhoto(Photo);

            if (Photo != null)
            {
                retour = new PhotoWCF();
                retour.ID = Photo.ID;
                retour.Convertir(Photo);

                if (String.IsNullOrEmpty(Photo.MessageErreur))
                    BusinessObject.SaveChanges();
            }

            return retour;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pID"></param>
        /// <returns></returns>
        public PhotoWCF GetPhoto(string pID)
        {

            BO BusinessObject = new BO();
            PhotoWCF retour = null;

            Photo_Entite Photo = BusinessObject.GetPhoto(int.Parse(pID));

            if (Photo != null)
            {
                retour = new PhotoWCF();
                retour.Convertir(Photo);

            }

            return retour;
        }

        public string DeletePhoto(string pID)
        {
            if (BusinessObject.SupprimerPhoto(int.Parse(pID)))
                return BusinessObject.MessageErreur;

            return "";

        }

        public PhotoWCF UpdatePhoto(PhotoWCF pPhoto)
        {
            Photo_Entite Photo = (Photo_Entite)pPhoto.Convertir();
            Photo = BusinessObject.UpdatePhoto(Photo);
            if (string.IsNullOrEmpty(Photo.MessageErreur))
                BusinessObject.SaveChanges();
            pPhoto.Convertir(Photo);
            return pPhoto;
        }


        #endregion


        #region " Alerte "

        public List<AlerteWCF> ObtenirAlertes()
        {
            AlerteWCF alerteWCF = new AlerteWCF();
            
            List<AlerteWCF> retour = new List<AlerteWCF>();
            List<Alerte_Entite> alertes = BusinessObject.ObternirAlertes(alerteWCF.Convertir());

            foreach (Alerte_Entite alerte in alertes)
            {
                alerteWCF = new AlerteWCF();
                alerteWCF.Convertir(alerte);
                retour.Add(alerteWCF);
            }

            return retour;
        }
        public List<AlerteWCF> ObtenirAlerte(string pID) {
            
            AlerteWCF alerteWCF = new AlerteWCF() { ID = int.Parse( pID )};
            List<AlerteWCF> retour = new List<AlerteWCF>();
            List<Alerte_Entite> alertes = BusinessObject.ObternirAlertes(alerteWCF.Convertir());

            foreach (Alerte_Entite alerte in alertes)
            {
                alerteWCF =new AlerteWCF();
                alerteWCF.Convertir(alerte);
                retour.Add(alerteWCF);
            }

            return retour;
        }
#endregion
        public bool SupprimerAlertes(AlerteWCF pAlerte) {

            bool retour = BusinessObject.SupprimerAlerte(pAlerte.Convertir());
            if (retour==true)
                BusinessObject.SaveChanges();
            return retour;

        }
        public AlerteWCF AjouterAlertes(AlerteWCF pAlerte) {
         
            AlerteWCF retour = new AlerteWCF();
            Alerte_Entite alerteEnt = new Alerte_Entite();

            try{
                retour.Convertir(BusinessObject.CreerAlerte(pAlerte.Convertir()));
                if (string.IsNullOrEmpty(retour.MessageErreur))
                    BusinessObject.SupprimerAlerte(pAlerte.Convertir());
            }
            catch (Exception Exception ){
                retour.MessageErreur = Exception.Message ;
            }

            return retour;
        }

        public UsagerWCF Login(string pUserName, string pPassword){
        
            UsagerWCF retour = new UsagerWCF();

            Usager_Entite usager = BusinessObject.Login(pUserName,
                pPassword);
            retour.Convertir(usager);
            return  retour;
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing) {
            if (disposing)
                if (aBusinessObject != null) {
                    aBusinessObject.Dispose();
                    aBusinessObject = null;
                }
        }
        ~ServiceWCF_Synthese() {
            Dispose(false);
        }
    }
}
//TODO: Obtenir une liste de photos avec photos et sons
//TODO: Insérer un oiseau et ses photos et ses sons

using BO_Synthese.DTO;
using Data_synthese;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO_Synthese
{
    public class PhotoObservationRepository : BO
    {
        #region property
        private PhotoObservationDTO CurrentPhotoObservationDto;
        private synthese_dbEntities DbContext;
        #endregion

        #region constructor
        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public PhotoObservationRepository()
        {
            CurrentPhotoObservationDto = null;
            DbContext = new synthese_dbEntities();
        }
        #endregion

        #region public
        /// <summary>
        /// Retourne une observation pour un ID
        /// </summary>
        /// <param name="id">Le id de l'observation</param>
        /// <returns>L'observation contenant le ID en question</returns>
        public PhotoObservationDTO GetPhotoObservationFromId(int id)
        {
            var list = (from photoobservation in DbContext.photoobservation
                        where photoobservation.Id == id
                        select photoobservation);

            foreach (photoobservation photoobservation in list)
                return PhotoObservationDbToDto(photoobservation);

            return null;

        }

        /// <summary>
        /// Cette methode permet d'ajouter une photo d'observation
        /// </summary>
        /// <param name="photoObservation"></param>
        public void CreatePhotoObservation(PhotoObservationDTO photoObservation)
        {
            CurrentPhotoObservationDto = photoObservation;
            if (!CurrentPhotoObservationDto.IsValid())
                throw new Exception("Impossible d'enregistrer l'image.");

            DbContext.photoobservation.Add(PhotoObservationDtoToDb());
            DbContext.SaveChanges();
        }
        #endregion

        #region private
        /// <summary>
        /// Permet de transformer une observation provenant de la BD en observation
        /// pouvant être enregistrée dans la bd
        /// </summary>
        /// <param name="photo"></param>
        /// <returns></returns>
        private PhotoObservationDTO PhotoObservationDbToDto(photoobservation photo)
        {
            PhotoObservationDTO photoObservationDto = new PhotoObservationDTO()
            {
                Id = photo.Id,
                IDObservation = photo.IDObservation,
                Image = photo.Image,
                Description = photo.Description,
                Commentaire = photo.Commentaire
            };

            return photoObservationDto;
        }

        private photoobservation PhotoObservationDtoToDb()
        {
            return new photoobservation
            {
                IDObservation = CurrentPhotoObservationDto.IDObservation,
                Description = CurrentPhotoObservationDto.Description,
                Commentaire = CurrentPhotoObservationDto.Commentaire,
                Image = CurrentPhotoObservationDto.Image
            };
        }
        #endregion
    }
}

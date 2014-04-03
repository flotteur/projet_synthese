using BO_Synthese.DTO;
using Data_synthese;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Text;

namespace BO_Synthese
{
    public sealed class PhotoRepository : BO
    {
        #region const
        private const string typeOiseau = "oiseau";
        private const string typeObservation = "observation";
        #endregion

        #region property
        private PhotoObservationDTO CurrentPhotoObservationDto;
        private synthese_dbEntities DbContext;
        private string type;
        private int photoId;
        #endregion

        #region constructor
        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public PhotoRepository(string type, int id)
        {
            CurrentPhotoObservationDto = null;
            DbContext = new synthese_dbEntities();
            photoId = id;

            if (type.Equals(typeOiseau) || type.Equals(typeObservation))
            {
                this.type = type;
            }
            else
            {
                throw new Exception("Type invalide");
            }
        }

        public PhotoRepository()
        {
            CurrentPhotoObservationDto = null;
            DbContext = new synthese_dbEntities();
        }
        #endregion

        #region public
        public byte[] GetPhoto()
        {

            if (type.Equals(typeOiseau))
            {
                PhotoOiseauDTO photoOiseau = GetPhotoOiseauFromId(photoId);

                if (photoOiseau != null)
                {
                    return photoOiseau.Image;
                }                    
            }
            else if (type.Equals(typeObservation))
            {
                PhotoObservationDTO photoObservation = GetPhotoObservationFromId(photoId);

                if (photoObservation != null)
                {
                    return GetPhotoObservationFromId(photoId).Image;
                }
            }

            return null;
        }

        /// <summary>
        /// Cette methode permet d'ajouter une photo d'observation
        /// </summary>
        /// <param name="photoObservation"></param>
        public void CreatePhotoObservation(int id, string photo)
        {
            CurrentPhotoObservationDto = new PhotoObservationDTO();
            //if (!CurrentPhotoObservationDto.IsValid())
            //    throw new Exception("Impossible d'enregistrer l'image.");

            CurrentPhotoObservationDto.IDObservation = id;
            CurrentPhotoObservationDto.Image = Convert.FromBase64String(photo);
            CurrentPhotoObservationDto.Description = "Description";
            CurrentPhotoObservationDto.Path = "Path inutile";


            DbContext.photoobservation.Add(PhotoObservationDtoToDb());

            try
            {
                DbContext.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" + sb, ex); // Add the original exception as the innerException
            }
            
        }
        #endregion

        #region private
        /// <summary>
        /// Retourne une observation pour un ID
        /// </summary>
        /// <param name="id">Le id de l'observation</param>
        /// <returns>L'observation contenant le ID en question</returns>
        private PhotoObservationDTO GetPhotoObservationFromId(int id)
        {
            if (this.type.Equals(typeObservation))
            {
                var list = (from photoobservation in DbContext.photoobservation
                            where photoobservation.Id == id
                            select photoobservation);

                foreach (photoobservation photoobservation in list)
                    return PhotoObservationDbToDto(photoobservation);
            }

            return null;

        }

        /// <summary>
        /// Retourne une photo d'oiseau
        /// </summary>
        /// <param name="id">id oiseau</param>
        /// <returns>photo oiseau</returns>
        private PhotoOiseauDTO GetPhotoOiseauFromId(int id)
        {
            if (this.type.Equals(typeOiseau))
            {
                var photo = (from photoOiseau in DbContext.photo
                             where photoOiseau.Id == id
                             select photoOiseau).First();

                return PhotoOiseauDbToDto(photo);
            }

            return null;
        }

        /// <summary>
        /// Permet de transformer une observation provenant de la BD en observation
        /// pouvant être enregistrée dans la bd
        /// </summary>
        /// <param name="photo"></param>
        /// <returns></returns>
        private PhotoObservationDTO PhotoObservationDbToDto(photoobservation photo)
        {
            var photoObservationDto = new PhotoObservationDTO()
            {
                Id = photo.Id,
                IDObservation = photo.IDObservation,
                Image = photo.Image,
                //Description = photo.Description,
                //Commentaire = photo.Commentaire
            };

            return photoObservationDto;
        }


        /// <summary>
        /// Permet de transformer une observation provenant de la BD en observation
        /// pouvant être enregistrée dans la bd
        /// </summary>
        /// <param name="photo"></param>
        /// <returns></returns>
        private PhotoOiseauDTO PhotoOiseauDbToDto(photo photo)
        {
            var photoOiseauDto = new PhotoOiseauDTO()
            {
                Id = photo.Id,
                Image = photo.Image
            };

            return photoOiseauDto;
        }

        /// <summary>
        /// Convertion d'une photo DTO en photo BD
        /// </summary>
        /// <returns></returns>
        private photoobservation PhotoObservationDtoToDb()
        {
            return new photoobservation
            {
                IDObservation = CurrentPhotoObservationDto.IDObservation,
                Description = CurrentPhotoObservationDto.Description,
                Image = CurrentPhotoObservationDto.Image,
                Path = CurrentPhotoObservationDto.Path
            };
        }
        #endregion
    }
}

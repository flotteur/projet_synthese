using BO_Synthese.DTO;
using Data_synthese;
using System;
using System.Collections.Generic;
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
        #endregion

        #region public
        public byte[] GetPhoto()
        {
            
            if (type.Equals(typeOiseau))
            {
                return GetPhotoOiseauFromId(photoId).Image;
            }
            else if (type.Equals(typeObservation))
            {
                return GetPhotoObservationFromId(photoId).Image;
            }

            return null;
        }

        /// <summary>
        /// Cette methode permet d'ajouter une photo d'observation
        /// </summary>
        /// <param name="photoObservation"></param>
        public void CreatePhotoObservation(string id, string filename, Stream photoObservation)
        {
            CurrentPhotoObservationDto = new PhotoObservationDTO();
            //if (!CurrentPhotoObservationDto.IsValid())
            //    throw new Exception("Impossible d'enregistrer l'image.");

            //add convert Stram to byte[]
            byte[] buffer = StreamToByte(photoObservation);
            //create image record for database
            CurrentPhotoObservationDto.Image = buffer;
            CurrentPhotoObservationDto.IDObservation = 1;
            CurrentPhotoObservationDto.Description = "qewq";
            CurrentPhotoObservationDto.Commentaire = "fjshf";

            DbContext.photoobservation.Add(PhotoObservationDtoToDb());
            DbContext.SaveChanges();
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
                Description = photo.Description,
                Commentaire = photo.Commentaire
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
                Commentaire = CurrentPhotoObservationDto.Commentaire,
                Image = CurrentPhotoObservationDto.Image
            };
        }

        /// <summary>
        /// Conversion d'un stream en byte[] pour enregistrer dans la bd
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static byte[] StreamToByte(Stream stream)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
        #endregion
    }
}

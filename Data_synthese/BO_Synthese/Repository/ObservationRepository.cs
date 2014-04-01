using Data_synthese;
using Data_synthese.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO_Synthese
{
    public sealed class ObservationRepository : BO
    {
        #region fields
        private ObservationDTO currentObservationDto;
        private synthese_dbEntities dbContext;
        private Session session;
        #endregion

        #region constructor

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public ObservationRepository()
        {
            currentObservationDto = null;
            dbContext = new synthese_dbEntities();
            this.session = Session.getInstance();
        }

        public ObservationRepository(ObservationDTO observationDto)
        {
            currentObservationDto = observationDto;
            dbContext = new synthese_dbEntities();
            this.session = Session.getInstance();
        }

        /// <summary>
        /// Constructeur avec les informations d'une observation découpée
        /// </summary>
        /// <param name="idUsager">L'id de l'usager</param>
        /// <param name="idOiseau">L'id de l'oiseau</param>
        /// <param name="date">La date de l'observation</param>
        /// <param name="latitude">La latitude</param>
        /// <param name="longitude">La logitude</param>
        //public ObservationRepository(int idUsager, int idOiseau, DateTime date, int latitude, int longitude)
        //{
        //    CurrentObservation = new ObservationDTO(idUsager, idOiseau, date, latitude, longitude);
        //}
        #endregion

        #region public
        /// <summary>
        /// Permet l'insertion de l'observation dans la BD
        /// </summary>
        /// <param name="observation">L'observation à insérer</param>
        /// <returns>L'observation qui a été inséré dans la BD</returns>
        public void createObservation()
        {
            if (!currentObservationDto.isValid() && session.usager != null)
                throw new Exception("L'observation est incomplète.");

            dbContext.observation.Add(ObservationDtoToDb());
            dbContext.SaveChanges();
        }

        /// <summary>
        /// Retourne une observation pour un ID
        /// </summary>
        /// <param name="id">Le id de l'observation</param>
        /// <returns>L'observation contenant le ID en question</returns>
        public ObservationDTO GetObservationFromId(int id)
        {
            var list = (from observation in dbContext.observation
                        where observation.Id == id
                        select observation).ToList();

            foreach (observation observation in list)
                return ObservationDbToDto(observation);

            return null;

        }

        /// <summary>
        /// Retourne la liste de toutes les observations
        /// </summary>
        /// <returns>La liste de toutes les observations</returns>
        public List<ObservationDTO> GetAllObservation()
        {
            var listObservationDto = new List<ObservationDTO>();

            var listObservation = (from ob in dbContext.observation
                                   orderby ob.DateObservation descending
                                    select ob).ToList();
            
            foreach (observation observation in listObservation)
            {
                listObservationDto.Add(ObservationDbToDto(observation));
            }
                
            return listObservationDto;

        }

        /// <summary>
        /// Permet la supression d'une observation
        /// </summary>
        /// <param name="id">L'id de l'observation</param>
        /// <returns>Le succès de l'opération</returns>
        public void DeleteObservation(int id)
        {
            if (session.usager.EstAdministrateur == true)
            {
                var observation = new observation();
                observation.Id = id;

                dbContext.observation.Remove(observation);
                dbContext.SaveChanges();
            }
        }
        #endregion

        #region private
        /// <summary>
        /// Transforme l'observationDto courante en observation BD
        /// </summary>
        /// <returns>L'observation BD</returns>
        private observation ObservationDtoToDb()
        {
            var observation = new observation() 
            {
                IDOiseau = currentObservationDto.IDOiseau,
                IDUsager = currentObservationDto.IDUsager,
                DateObservation = currentObservationDto.DateObservation,
                PositionLat = currentObservationDto.Latitude,
                PositionLong = currentObservationDto.Longitude,
                Titre = currentObservationDto.Titre,
                Detail = currentObservationDto.Detail
            };

            return observation;
        }

        /// <summary>
        /// Transforme une observation en observationDto
        /// </summary>
        /// <param name="observation">L'observation en provenance de la bd</param>
        /// <returns>Une observation pour le service web</returns>
        private ObservationDTO ObservationDbToDto(observation observation)
        {
            var observationDto = new ObservationDTO()
            {
                IDOiseau = observation.IDOiseau,
                IDUsager = observation.IDUsager,
                DateObservation = observation.DateObservation,
                Longitude = observation.PositionLong,
                Latitude = observation.PositionLat,
                Titre = observation.Titre,
                Id = observation.Id,
                Detail = observation.Detail
            };

            observationDto.Usager = new DTO.UsagerDTO()
            {
                Nom = observation.usagers.Nom,
                NomUsager = observation.usagers.NomUsager,
                ID = observation.usagers.Id
            };

            observationDto.Oiseau = new DTO.OiseauDTO()
            {
                Id = observation.oiseaux.Id,
                Espece = observation.oiseaux.Espece,
                Description = observation.oiseaux.Description
            };

            return observationDto;
        }
        #endregion
    }
}

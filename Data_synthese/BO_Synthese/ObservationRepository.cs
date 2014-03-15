using Data_synthese;
using Data_synthese.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO_Synthese
{
    public class ObservationRepository : BO
    {
        #region property
        private ObservationDTO CurrentObservationDto;
        private synthese_dbEntities DbContext;
        #endregion

        #region constructor

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public ObservationRepository()
        {
            CurrentObservationDto = null;
            DbContext = new synthese_dbEntities();
        }

        public ObservationRepository(ObservationDTO observationDto)
        {
            CurrentObservationDto = observationDto;
            DbContext = new synthese_dbEntities();
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
            if (!CurrentObservationDto.isValid())
                throw new Exception("L'observation est incomplète.");

            DbContext.observation.Add(ObservationDtoToDb());
            DbContext.SaveChanges();
        }

        /// <summary>
        /// Retourne une observation pour un ID
        /// </summary>
        /// <param name="id">Le id de l'observation</param>
        /// <returns>L'observation contenant le ID en question</returns>
        public ObservationDTO GetObservationFromId(int id)
        {
            var list = (from observation in DbContext.observation
                        where observation.Id == id
                        select observation);

            foreach (Observation observation in list)
                return ObservationDbToDto(observation);

            return null;

        }
        #endregion

        #region private
        /// <summary>
        /// Transforme l'observationDto courante en observation BD
        /// </summary>
        /// <returns>L'observation BD</returns>
        private Observation ObservationDtoToDb()
        {
            var observation = new Observation() 
            {
                IDOiseau = CurrentObservationDto.IDOiseau,
                IDUsager = CurrentObservationDto.IDUsager,
                DateObservation = CurrentObservationDto.DateObservation
            };

            return observation;
        }

        /// <summary>
        /// Transforme une observation en observationDto
        /// </summary>
        /// <param name="observation">L'observation en provenance de la bd</param>
        /// <returns>Une observation pour le service web</returns>
        private ObservationDTO ObservationDbToDto(Observation observation)
        {
            var observationDto = new ObservationDTO()
            {
                IDOiseau = observation.IDOiseau,
                IDUsager = observation.IDUsager,
                DateObservation = observation.DateObservation
            };

            return observationDto;
        }
        #endregion
    }
}

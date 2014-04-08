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
        public ObservationRepository() {
            currentObservationDto = null;
            dbContext = new synthese_dbEntities();
            this.session = Session.getInstance();
        }

        public ObservationRepository(ObservationDTO observationDto) {
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
        public ObservationDTO CreateObservation() {
            if (!currentObservationDto.isValid() && session.usager != null)
                throw new Exception("L'observation est incomplète.");

            observation observationDb = dbContext.observation.Add(ObservationDtoToDb());

            dbContext.SaveChanges();
            // On peut annoncer la bonne nouvelle

            var bo = new BO();
            bo.SendAlerte(observationDb.IDOiseau);

            return ObservationDbToDto(observationDb);
        }

        /// <summary>
        /// Permet l'insertion de l'observation dans la BD
        /// </summary>
        /// <param name="observation">L'observation à insérer</param>
        /// <returns>L'observation qui a été inséré dans la BD</returns>
        public ObservationDTO UpdateObservation() {
            if (!currentObservationDto.isValid())
                throw new Exception("L'observation est incomplète.");

            if (session.usager == null)
                throw new Exception("Vous devez être authentifié pour effectuer cette action.");

            if (session.usager.ID != currentObservationDto.IDUsager)
                throw new Exception("Vous ne pouvez modifier cette observation.");

            var observationUpdate = (from observation in dbContext.observation
                                     where observation.Id == currentObservationDto.Id
                                     select observation).First();

            observationUpdate.IDOiseau = currentObservationDto.IDOiseau;
            observationUpdate.PositionLat = currentObservationDto.Latitude;
            observationUpdate.PositionLong = currentObservationDto.Longitude;
            observationUpdate.Titre = currentObservationDto.Titre;
            observationUpdate.Detail = currentObservationDto.Detail;

            dbContext.SaveChanges();

            return ObservationDbToDto(observationUpdate);
        }

        /// <summary>
        /// Retourne une observation pour un ID
        /// </summary>
        /// <param name="id">Le id de l'observation</param>
        /// <returns>L'observation contenant le ID en question</returns>
        public ObservationDTO GetObservationFromId(int id) {
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
        public List<ObservationDTO> GetAllObservation() {
            var listObservationDto = new List<ObservationDTO>();

            var listObservation = (from ob in dbContext.observation
                                   orderby ob.DateObservation descending
                                   select ob).ToList();

            foreach (observation observation in listObservation) {
                listObservationDto.Add(ObservationDbToDto(observation));
            }

            return listObservationDto;
        }

        /// <summary>
        /// Permet la supression d'une observation
        /// </summary>
        /// <param name="id">L'id de l'observation</param>
        /// <returns>Le succès de l'opération</returns>
        public void DeleteObservation(int id) {
            if (session.usager.EstAdministrateur == false || session.usager == null) {
                return;
            }

            // Pour le delete de l'observation
            var observation = new observation();
            observation.Id = id;

            // Pour le delete des commentaire
            var listCommentaire = (from comment in dbContext.Commentaire
                                   where comment.observationId == id
                                   select comment).ToList();

            foreach (Commentaire comment in listCommentaire) {
                dbContext.Commentaire.Remove(comment);
            }

            // Pour le delete des photos
            var listPhoto = (from pic in dbContext.photoobservation
                             where pic.IDObservation == id
                             select pic).ToList();

            foreach (photoobservation pic in listPhoto) {
                dbContext.photoobservation.Remove(pic);
            }

            var observationDb = (from observ in dbContext.observation
                                 where observ.Id == id
                                 select observ).First();

            if (observationDb != null) {
                // Delete de l'observation
                dbContext.observation.Remove(observationDb);
            }

            dbContext.SaveChanges();
        }

        #endregion

        #region private

        /// <summary>
        /// Transforme l'observationDto courante en observation BD
        /// </summary>
        /// <returns>L'observation BD</returns>
        private observation ObservationDtoToDb() {
            var observation = new observation() { IDOiseau = currentObservationDto.IDOiseau,
                                                  IDUsager = currentObservationDto.IDUsager,
                                                  DateObservation = currentObservationDto.DateObservation,
                                                  PositionLat = currentObservationDto.Latitude,
                                                  PositionLong = currentObservationDto.Longitude,
                                                  Titre = currentObservationDto.Titre,
                                                  Detail = currentObservationDto.Detail };

            return observation;
        }

        /// <summary>
        /// Transforme une observation en observationDto
        /// </summary>
        /// <param name="observation">L'observation en provenance de la bd</param>
        /// <returns>Une observation pour le service web</returns>
        private ObservationDTO ObservationDbToDto(observation observation) {
            var observationDto = new ObservationDTO() { IDOiseau = observation.IDOiseau,
                                                        IDUsager = observation.IDUsager,
                                                        DateObservation = observation.DateObservation,
                                                        Longitude = observation.PositionLong,
                                                        Latitude = observation.PositionLat,
                                                        Titre = observation.Titre,
                                                        Id = observation.Id,
                                                        Detail = observation.Detail };

            if (observation.usagers != null) {
                observationDto.Usager = new DTO.UsagerDTO() { Nom = observation.usagers.Nom,
                                                              NomUsager = observation.usagers.NomUsager,
                                                              ID = observation.usagers.Id };
            }

            if (observation.oiseaux != null) {
                observationDto.Oiseau = new DTO.OiseauDTO() { Id = observation.oiseaux.Id,
                                                              Espece = observation.oiseaux.Espece,
                                                              Description = observation.oiseaux.Description };
            }

            if (observation.photoobservations != null) {
                foreach (photoobservation pic in observation.photoobservations) {
                    observationDto.ListePathPhoto.Add(@"/image/observation/" + pic.Id);
                    }
                }

                return observationDto;
            }

            #endregion

        }
    }

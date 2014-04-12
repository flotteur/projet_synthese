using BO_Synthese.DTO;
using Data_synthese;
using Data_synthese.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO_Synthese.Repository
{
    public sealed class CommentaireRepository : BO, IRepository<CommentaireDTO, Commentaire>
    {
        #region fields
        private synthese_dbEntities dbContext;
        private CommentaireDTO currentCommentaireDto;
        private Session session;
        #endregion

        #region constructor
        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public CommentaireRepository()
        {
            currentCommentaireDto = null;
            dbContext = new synthese_dbEntities();
            this.session = Session.getInstance();
        }

        /// <summary>
        /// Constructeur avec CommentaireDTO
        /// </summary>
        /// <param name="commentaireDto"></param>
        public CommentaireRepository(CommentaireDTO commentaireDto)
        {
            currentCommentaireDto = commentaireDto;
            dbContext = new synthese_dbEntities();
            this.session = Session.getInstance();
        }
        #endregion

        #region public
        /// <summary>
        /// Ajout d'un commentaire
        /// </summary>
        /// <param name="commentaireDto">Le commentaire</param>
        /// <returns>Le commentaire</returns>
        public CommentaireDTO AddCommentaire(CommentaireDTO commentaireDto)
        {
            commentaireDto.DateBd = DateTime.Now;
            dbContext.Commentaire.Add(ToBD(commentaireDto));
            dbContext.SaveChanges();

            return commentaireDto;
        }

        /// <summary>
        /// Permet d'obtenir un commentaire en fonction du ID du commentaire
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CommentaireDTO GetCommentaire(int id)
        {
            Commentaire commentaire = (from comment in dbContext.Commentaire
                        where comment.Id == id
                        orderby comment.DateCommentaire descending
                        select comment).First();

            return ToDto(commentaire);

        }

        /// <summary>
        /// Liste des commentaire pour une observation
        /// </summary>
        /// <param name="observationId">Id de l'observation</param>
        /// <returns>La liste des observations</returns>
        public List<CommentaireDTO> GetListCommentaire(int observationId)
        {
            var listCommentaireDto = new List<CommentaireDTO>();

            List<Commentaire> commentaireList = (from comment in dbContext.Commentaire
                                                 where comment.observationId == observationId
                                                 orderby comment.DateCommentaire descending
                                                 select comment).ToList();

            foreach (Commentaire commentaire in commentaireList)
            {
                listCommentaireDto.Add(ToDto(commentaire));
            }

            return listCommentaireDto;
        }

        /// <summary>
        /// Permet de supprimer un commentaire 
        /// </summary>
        /// <param name="id">Id du commentaire</param>
        public bool DeleteCommentaire(int id)
        {
            if ((session.usager != null) && (session.usager.EstAdministrateur == true))
            {
                //var commentaire = new Commentaire();
                //commentaire.Id = id;

                var commentaireDb = (from comment in dbContext.Commentaire
                                     where comment.Id == id
                                     select comment).First();

                if (commentaireDb != null)
                {
                    // Delete de l'observation
                    dbContext.Commentaire.Remove(commentaireDb);
                }
                else
                {
                    return false;
                }

                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Conversion commentaireDTO vers Commentaire
        /// </summary>
        /// <param name="commentaireDto">Commentaire du service</param>
        /// <returns>Commentaire BD</returns>
        public Commentaire ToBD(CommentaireDTO commentaireDto)
        {

            return new Commentaire() 
            { 
                IDUsager = commentaireDto.IDUsager,
                observationId = commentaireDto.observationId,
                Texte = commentaireDto.Texte,
                DateCommentaire = commentaireDto.DateBd
            };
        }

        /// <summary>
        /// Conversion Commentaire vers CommentaireDTO
        /// </summary>
        /// <param name="commentaireBD">Commentaire BD</param>
        /// <returns>un commentaire pour le service</returns>
        public CommentaireDTO ToDto(Commentaire commentaireBD)
        {
            return new CommentaireDTO()
            {
                Id = commentaireBD.Id,
                IDUsager = commentaireBD.IDUsager,
                Texte = commentaireBD.Texte,
                observationId = commentaireBD.observationId,
                DateBd = commentaireBD.DateCommentaire
            };
        }
        #endregion
    }
}

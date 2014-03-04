using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data_synthese.Classes;

namespace Data_synthese
{
    public partial class Observation
    {
        #region propriétés
        private synthese_dbEntities DbContext;
        #endregion
        
        #region public
        /// <summary>
        /// Permet l'insertion de l'observation dans la BD
        /// </summary>
        /// <param name="observation">L'observation à insérer</param>
        /// <returns>L'observation qui a été inséré dans la BD</returns>
        public Observation Insert(Observation observation)
        {
            if (observation.isValid())
                throw new Exception();

            return DbContext.observation.Add(observation);
        }

        /// <summary>
        /// Vérifie si l'observation est valide
        /// </summary>
        /// <returns>True si valide</returns>
        public bool isValid()
        {
            if(IDOiseau == null ||
                IDUsager == null)
            {
                return false;
            }
                
            return true;
        }
        #endregion
        
    }
}

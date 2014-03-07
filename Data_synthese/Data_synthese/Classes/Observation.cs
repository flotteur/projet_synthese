using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data_synthese.Classes;

namespace Data_synthese
{
    public partial class Observation : IObservation
    {
        #region public
        /// <summary>
        /// Permet l'insertion de l'observation dans la BD
        /// </summary>
        /// <param name="observation">L'observation à insérer</param>
        /// <returns>L'observation qui a été inséré dans la BD</returns>
        public Observation Insert()
        {
            if (!isValid())
                throw new Exception("L'observation est incomplète.");

            synthese_dbEntities dbContext = new synthese_dbEntities();
            Observation test = new Observation();
            test.IDOiseau = 1;
            test.DateObservation = DateTime.Now;
            test.IDUsager = 1;
            test.PositionLat = "ts";
            test.PositionLong = 12;

            dbContext.observation.Add(this);
            dbContext.SaveChanges();

            oiseau test2 = new oiseau();
            test2.Description = @"zxdas";
            test2.Espece = @"dsada";
            dbContext.oiseau.Add(test2);
            dbContext.SaveChanges();

            return this;
        }

        /// <summary>
        /// Vérifie si l'observation est valide
        /// </summary>
        /// <returns>True si valide</returns>
        public bool isValid()
        {
            if(IDOiseau > 1 || IDUsager > 1)
                return false;
                
            return true;
        }
        #endregion
        
    }
}

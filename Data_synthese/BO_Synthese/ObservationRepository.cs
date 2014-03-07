using Data_synthese;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO_Synthese
{
    public class ObservationRepository
    {
        #region propriétés

        #endregion

        #region public
        public void createObservation(Observation test)
        {
            test.Insert();
        }
        #endregion

        #region private

        #endregion
    }
}

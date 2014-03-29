using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entites_Synthese
{
    public class OiseauxList_Entite
    {
        /// <summary>
        /// La qté totale d'oiseaux dans la bd
        /// </summary>
        public int QteTotale { get; set; }
        private List<Oiseau_Entite> _Oiseaux = new List<Oiseau_Entite>();
        public List<Oiseau_Entite> Oiseaux
        {
            get {
                return _Oiseaux;}
            set {
                _Oiseaux = value;}
        }
    }

}

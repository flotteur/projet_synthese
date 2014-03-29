using System;
using System.Collections.Generic;
using System.Linq;
using Entites_Synthese;

namespace WCF_Synthese.EntitesWCF
{
    public class OiseauWCFList  
    {

        public int QteTotale { get; set; }
        private List<OiseauWCF> _OisseauxWCF = new List<OiseauWCF>();
        public List<OiseauWCF> OiseauxWCF
        {
            get {
                return _OisseauxWCF;
            }
            set {
                _OisseauxWCF = value;
            }
        }

        public void Convertir( OiseauxList_Entite pOiseauxListEnt){

            this.QteTotale = pOiseauxListEnt.QteTotale;
            foreach (Oiseau_Entite oiseau in pOiseauxListEnt.Oiseaux)
            {
                OiseauWCF oiseauWcf = new OiseauWCF();
                oiseauWcf.Convertir(oiseau);
                this.OiseauxWCF.Add(oiseauWcf);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Entites_Synthese;

namespace WCF_Synthese.EntitesWCF
{
    public class AlerteWCF : EntiteWCFBase
    {
        public int ID { get; set; }
        public int IDOiseau { get; set; }
        public int IDUsager  { get; set; }
        public UsagerWCF Usager { get; set; }
        public OiseauWCF Oiseau { get; set; }

        public void Convertir( Alerte_Entite pAlerteEntite) {
        
            this.ID = pAlerteEntite.ID;
            this.IDOiseau = pAlerteEntite.IDOiseau;
            this.IDUsager = pAlerteEntite.IDUsager;
            this.MessageErreur = pAlerteEntite.MessageErreur;
            if (pAlerteEntite.Usager !=null){
                UsagerWCF usager = new UsagerWCF();
                usager.Convertir(pAlerteEntite.Usager);
                this.Usager = usager;
            }

            if (pAlerteEntite.Oiseau !=null){
                OiseauWCF Oiseau = new OiseauWCF();
                Oiseau.Convertir(pAlerteEntite.Oiseau);
                this.Oiseau = Oiseau;
            }
            
        }

        public override Entites_Synthese.EntiteBase Convertir( ) {
        
            Alerte_Entite retour = new Alerte_Entite();

            retour.ID = this.ID;
            retour.IDOiseau = this.IDOiseau;
            retour.IDUsager = this.IDUsager;
            retour.MessageErreur = this.MessageErreur;
            if (this.Usager != null){
                retour.Usager =(Usager_Entite) this.Usager.Convertir();
            }

            if (this.Oiseau != null){
                retour.Oiseau = (Oiseau_Entite)this.Oiseau.Convertir();
            }
                        
            return retour;
        }
    }
}
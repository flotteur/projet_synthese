using System;
using System.Runtime.Serialization;
using Entites_Synthese;

namespace WCF_Synthese.EntitesWCF
{
    [DataContract]
    public class CriOiseauWCF : EntiteWCFBase
    {
        [DataMember(Name="ID")  ]
        public int ID { get; set; }
        [DataMember(Name = "IDOiseau")]
        public int IDOiseau { get; set; }
        [DataMember(Name = "Son")]
        public byte[] Son { get; set; }
        [DataMember(Name = "Description")]
        public String Description { get; set; }

        /// <summary>
        /// /// Converti un CriOiseauWCF en criOiseauEntite
        /// </summary>
        /// <returns></returns>
        public override EntiteBase Convertir() {

            CriOiseau_Entite retour = new CriOiseau_Entite() { ID = this.ID,
                                                               Description = this.Description,
                                                               IDOiseau = this.IDOiseau,
                                                               MessageErreur = this.MessageErreur,
                                                               Son = this.Son };
            
            return retour;
        }

        /// <summary>
        /// Converti un criOiseauEntite en CriOiseauWCF
        /// </summary>
        /// <param name="pCriOiseau"></param>
        public void Convertir( EntiteBase pCriOiseau){
        
            CriOiseau_Entite cri = (CriOiseau_Entite)pCriOiseau;
            this.ID = cri.ID;
            this.Description = cri.Description;
            this.IDOiseau = cri.IDOiseau;
            this.MessageErreur = pCriOiseau.MessageErreur;
        }

    }
}
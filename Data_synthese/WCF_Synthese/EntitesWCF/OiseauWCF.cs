using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Entites_Synthese;
namespace WCF_Synthese.EntitesWCF
{
    [DataContract]
    public class OiseauWCF : EntiteWCFBase
    {
        [DataMember(Name="ID")]
        public int ID { get; set; }
        [DataMember(Name = "Espece")]
        public string Espece { get; set; }
        [DataMember(Name = "Description")]
        public string Description { get; set; }

        private List<PhotoWCF>_Photos = new List<PhotoWCF> ();
        [DataMember(Name = "Photos")]
        public List<PhotoWCF> Photos
        {
            get {
                return _Photos;}
            set {
                _Photos = value;}
        }

        private List<CriOiseauWCF> _CrisOiseau = new List<CriOiseauWCF>();
        [DataMember(Name = "CrisOiseau")]
        public List<CriOiseauWCF> CrisOiseau
        {
            get {
                return _CrisOiseau;}
            set {
                _CrisOiseau = value;}
        }

        public void Convertir( Oiseau_Entite pOiseau){
            
            this.Description = pOiseau.Description;
            this.Espece = pOiseau.Espece;
            this.ID = pOiseau.ID ;
            this.MessageErreur = pOiseau.MessageErreur;
            
            foreach( Photo_Entite  photo in pOiseau.Photos){
                PhotoWCF photowcf = new PhotoWCF();
                photowcf.Convertir(photo);
                this.Photos.Add(photowcf);
            }

            foreach (CriOiseau_Entite cri in pOiseau.CrisOiseau)
            {
                CriOiseauWCF CriOiseauwcf = new CriOiseauWCF();
                CriOiseauwcf.Convertir(cri);
                this.CrisOiseau.Add(CriOiseauwcf);
            }

        
        }
    }
}
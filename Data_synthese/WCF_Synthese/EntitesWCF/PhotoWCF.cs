using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace WCF_Synthese.EntitesWCF
{
    [DataContract]
    public class PhotoWCF : EntiteWCFBase
    {
        [DataMember(Name = "ID")]
        public int ID { get; set; }
        [DataMember(Name = "IDOiseau")]
        public int IDOiseau { get; set; }
        [DataMember(Name = "Image")]
        public byte[] Image { get; set; }
        [DataMember(Name = "Description")]
        public string Description { get; set; }
        [DataMember(Name = "Path")]
        public string Path { get; set; }
        
        internal void Convertir(Entites_Synthese.Photo_Entite pPhoto) {
            this.Description = pPhoto.Description;
            this.ID = pPhoto.ID;
            this.IDOiseau = pPhoto.IDOiseau;
            this.Image = pPhoto.Image;
            this.MessageErreur = pPhoto.MessageErreur;
            this.Path = @"/image/oiseau/"+pPhoto.ID;
        }
    }
}
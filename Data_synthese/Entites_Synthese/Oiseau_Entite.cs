using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entites_Synthese
{
    public class Oiseau_Entite : EntiteBase
    {
        public int ID { get; set; }
        public string Espece { get; set; }
        public string Description { get; set; }

        private List<Photo_Entite> _Photos = new List<Photo_Entite>();
        public List<Photo_Entite> Photos
        {
            get {
                return _Photos;}
            set {
                _Photos = value;}
        }

        private List<CriOiseau_Entite> _CrisOiseau = new List<CriOiseau_Entite>();
        public List<CriOiseau_Entite> CrisOiseau
        {
            get {
                return _CrisOiseau;}
            set {
                _CrisOiseau = value;}
        }

        public override bool Validate()
        {
            return IsValid = !string.IsNullOrWhiteSpace(this.Espece  );
        }
    }
}
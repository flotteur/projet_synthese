using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entites_Synthese;

namespace Data_synthese
{
    public partial class oiseau
    {
        public Oiseau_Entite Convertir() {
            Oiseau_Entite oiseauEnt = new Oiseau_Entite();
            oiseauEnt.ID = this.Id;
            oiseauEnt.Description = this.Description;
            oiseauEnt.Espece = this.Espece;
            oiseauEnt.CrisOiseau = this.Convertir(this.crioiseaux);
            oiseauEnt.Photos = this.Convertir(this.photos.ToList());
            return oiseauEnt;
        }

        public void Convertir(Oiseau_Entite pOiseauEnt) {
            this.Id = pOiseauEnt.ID;
            this.Description = pOiseauEnt.Description;
            this.Espece = pOiseauEnt.Espece;
            this.crioiseaux = Convertir(pOiseauEnt.CrisOiseau);
            this.photos = Convertir(pOiseauEnt.Photos);
        }


        public List<Photo_Entite> Convertir(ICollection<photo> pListePhotos) {
            List<Photo_Entite> photos = new List<Photo_Entite>();

            if (pListePhotos != null)
                foreach (photo photo in pListePhotos) {
                    photos.Add(new Photo_Entite() { ID = photo.Id,
                                                    Description = photo.Description,
                                                    IDOiseau = photo.IDOiseau,
                                                    Image = photo.Image });
                }
            return photos;
        }

        public List<CriOiseau_Entite> Convertir(ICollection<crioiseau> pListeCriOiseau) {
            List<CriOiseau_Entite> crisOiseau = new List<CriOiseau_Entite>();
            if (pListeCriOiseau != null)
                foreach (crioiseau crioiseau in pListeCriOiseau) {
                    crisOiseau.Add(new CriOiseau_Entite() { ID = crioiseau.Id,
                                                            Description = crioiseau.Description,
                                                            IDOiseau = crioiseau.IDOiseau,
                                                            Son = crioiseau.Son });
                }
            return crisOiseau;
        }

        public ICollection<crioiseau> Convertir(List<CriOiseau_Entite> pListeCriOiseau) {
            ICollection<crioiseau> crisOiseau = new List<crioiseau>();
            if (pListeCriOiseau != null)
                foreach (CriOiseau_Entite crioiseau in pListeCriOiseau) {
                    crisOiseau.Add(new crioiseau() { Id = crioiseau.ID,
                                                     Description = crioiseau.Description,
                                                     IDOiseau = crioiseau.IDOiseau,
                                                     Son = crioiseau.Son });
                }
            return crisOiseau;
        }

        public ICollection<photo> Convertir(List<Photo_Entite> pListePhotos) {
            ICollection<photo> photos = new List<photo>();

            if (pListePhotos != null)
                foreach (Photo_Entite photo in pListePhotos) {
                    photos.Add(new photo() { Id = photo.ID,
                                             Description = photo.Description,
                                             IDOiseau = photo.IDOiseau,
                                             Image = photo.Image });
                }
            return photos;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_synthese.Classes
{

    public enum ErreursID
    {

        ID_ERREUR_ADMIN_REQUIS = 1,
        ID_ERREUR_NOM_UTILISATEUR_EXISTANT = 2,
        ID_ERREUR_COURRIEL_EXISTANT = 3,
        ID_ERREUR_LOGIN = 4,
        ID_ERREUR_USAGER_INEXISTANT = 5,
        ID_ERREUR_CONNEXION_REQUISE = 6,
        ID_ERREUR_INFOS_MANQUANTES = 7

    }
    class Constantes
    {
        
        public static string ERREUR_ADMIN_REQUIS = string.Format("{0}-{1}",(int) ErreursID.ID_ERREUR_ADMIN_REQUIS, "Vous devez être administrateur pour effecuer cette opération.");
        public static string ERREUR_NOM_UTILISATEUR_EXISTANT = string.Format("{0}-{1}", (int)ErreursID.ID_ERREUR_NOM_UTILISATEUR_EXISTANT, "Ce nom d'utilisateur est déjà utilisé.");
        public static string ERREUR_COURRIEL_EXISTANT = string.Format("{0}-{1}", (int)ErreursID.ID_ERREUR_COURRIEL_EXISTANT, "Ce courriel est déjà utilisé.");
        public static string ERREUR_LOGIN = string.Format("{0}-{1}", (int)ErreursID.ID_ERREUR_LOGIN, "Erreur au login de l'usager");
        public static string ERREUR_USAGER_INEXISTANT = string.Format("{0}-{1}", (int)ErreursID.ID_ERREUR_USAGER_INEXISTANT, "Usager inexistant");
        public static string ERREUR_CONNEXION_REQUISE = string.Format("{0}-{1}", (int)ErreursID.ID_ERREUR_CONNEXION_REQUISE, "Vous devez être connecté pour effectuer cette opération.");
        public static string ERREUR_INFOS_MANQUANTES = string.Format("{0}-{1}", (int)ErreursID.ID_ERREUR_INFOS_MANQUANTES, "Il manque des informations pour effectuer cette opération.");
    }
}

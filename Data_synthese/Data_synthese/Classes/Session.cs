using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entites_Synthese;

namespace Data_synthese.Classes
{
    public class Session
    {

        private static Session _instance;
        /// <summary>
        /// L'usager présentement loggué
        /// </summary>
        private Usager_Entite _usager;
        public Usager_Entite usager
        {
            get {
                return _usager;
            }
            set {
                _usager = value;
                LoginTime = DateTime.Now;
            }
        }

        
        public static Session getInstance(){
            if (_instance==null)
                _instance = new Session();
            return _instance;
        
        }

        public DateTime LoginTime { get; set; }

        private Session() { 
        
        }
    }
}

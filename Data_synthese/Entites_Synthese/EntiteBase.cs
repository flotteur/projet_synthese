using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entites_Synthese
{
    public class EntiteBase
    {
        public String MessageErreur { get; set; }

        public bool IsValid { get; set;}


        public virtual  bool Validate()
        {
            IsValid = true;
            return true;
        }
    }
}

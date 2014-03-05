using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_synthese.Exceptions
{
    public class CourrielExistantException   : Exception 
    {
        public CourrielExistantException()
        {
        }

        public CourrielExistantException(string message)
            : base(message)
        {
        }

        public CourrielExistantException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

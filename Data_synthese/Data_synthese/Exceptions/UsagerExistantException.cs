using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_synthese.Exceptions
{
    public class UsagerExistantException : Exception
    {
        public UsagerExistantException()
        {
        }

        public UsagerExistantException(string message)
            : base(message)
        {
        }

        public UsagerExistantException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

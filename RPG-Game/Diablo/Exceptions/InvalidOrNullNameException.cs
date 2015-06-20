using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diablo.Exceptions
{
    class InvalidOrNullNameException : Exception
    {
        public InvalidOrNullNameException(String message)
            : base(message)
        {
        }
    }
}

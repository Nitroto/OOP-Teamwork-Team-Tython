using System;

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

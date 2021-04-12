using System;

namespace Algorithm.Logic.Exceptions
{
    public class CoordenadaException : Exception
    {
        public CoordenadaException()
        {

        }
        public CoordenadaException(string message) : base(message)
        {

        }
        public CoordenadaException(string message, Exception innerException) : base(message, innerException)
        {
           
        }
    }
}

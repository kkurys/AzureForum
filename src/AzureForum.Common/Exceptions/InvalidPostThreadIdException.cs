using System;
using System.Runtime.Serialization;

namespace AzureForum.Common.Exceptions
{
    public class InvalidPostThreadIdException : Exception
    {
        public InvalidPostThreadIdException()
        {
        }

        public InvalidPostThreadIdException(string message) : base(message)
        {
        }

        public InvalidPostThreadIdException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidPostThreadIdException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

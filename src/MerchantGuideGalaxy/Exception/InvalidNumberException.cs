using System;
using System.Runtime.Serialization;

namespace MerchantGuideGalaxy.Exception
{
    [Serializable]
    public class InvalidNumberException : System.Exception
    {
        public InvalidNumberException()
        {
        }

        public InvalidNumberException(string message)
            : base(message)
        {
        }

        public InvalidNumberException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }

        protected InvalidNumberException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

    }
}

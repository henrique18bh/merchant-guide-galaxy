using System;
using System.Runtime.Serialization;

namespace MerchantGuideGalaxy.Exception
{
    [Serializable]
    public class TypeExecutionException : System.Exception
    {
        public TypeExecutionException()
        {
        }

        public TypeExecutionException(string message)
            : base(message)
        {
        }

        public TypeExecutionException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }

        protected TypeExecutionException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

    }
}

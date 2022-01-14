using System;
using System.Runtime.Serialization;

namespace TestConsoleApp
{
    [Serializable]
    public class YourAppException : ApplicationException
    {
        public YourAppException(string message)
            : base(message)
        {
        }

        public YourAppException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected YourAppException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
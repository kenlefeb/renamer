using System;
using System.Runtime.Serialization;

namespace Tests
{
    [Serializable]
    internal class FailedToParseSceneNameException : Exception
    {
        public FailedToParseSceneNameException()
        {
        }

        public FailedToParseSceneNameException(string message) : base(message)
        {
        }

        public FailedToParseSceneNameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FailedToParseSceneNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
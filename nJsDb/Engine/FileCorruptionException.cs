using System;
using System.Runtime.Serialization;

namespace nJsDb.LoadObjectFromFile
{
    [Serializable]
    internal class FileCorruptionException : Exception
    {
        public FileCorruptionException()
        {
        }

        public FileCorruptionException(string message) : base(message)
        {
        }

        public FileCorruptionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FileCorruptionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
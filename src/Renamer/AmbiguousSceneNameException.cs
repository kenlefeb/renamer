using System;
using System.IO.Abstractions;
using System.Runtime.Serialization;

namespace Renamer
{
    [Serializable]
    internal class AmbiguousSceneNameException : Exception
    {
        private IFileInfo? file;
        private IDirectoryInfo? folder;

        public AmbiguousSceneNameException(IFileInfo file)
        {
            this.file = file;
        }

        public AmbiguousSceneNameException(string message) : base(message)
        {
        }

        public AmbiguousSceneNameException(IDirectoryInfo folder)
        {
            this.folder = folder;
        }

        public AmbiguousSceneNameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AmbiguousSceneNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
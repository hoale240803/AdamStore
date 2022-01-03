using System;

namespace Shared.Utilities.Exceptions
{
    public class AdamStoreException : Exception
    {
        public AdamStoreException()
        {
        }

        public AdamStoreException(string message)
            : base(message)
        {
        }

        public AdamStoreException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
using System;

namespace Exceptions
{
    public class InvalidPercentageException : Exception
    {
        public InvalidPercentageException(string message) : base(message)
        {
        }
    }
}
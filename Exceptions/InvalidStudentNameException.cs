﻿using System;

namespace Exceptions
{
   public class InvalidNameException : Exception 
    {
        public InvalidNameException(string message) : base(message)
        {

        }
    }
}

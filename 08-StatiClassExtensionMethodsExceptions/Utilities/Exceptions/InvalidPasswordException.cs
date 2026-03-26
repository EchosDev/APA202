using System;
using System.Collections.Generic;
using System.Text;

namespace _08_StatiClassExtensionMethodsExceptions.Utilities.Exceptions
{
    internal class InvalidPasswordException : Exception
    {
        private static string _message = "Password cannot be empty or less than 6 characters.";

        public InvalidPasswordException() : base(_message) { }

        public InvalidPasswordException(string message) : base(message) { }
    }
}

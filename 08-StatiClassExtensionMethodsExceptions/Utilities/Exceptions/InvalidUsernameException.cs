using System;
using System.Collections.Generic;
using System.Text;

namespace _08_StatiClassExtensionMethodsExceptions.Utilities.Exceptions
{
    internal class InvalidUsernameException : Exception
    {
        private static string _message = "Username cannot be empty or less than 3 characters.";
        public InvalidUsernameException() : base(_message) { }
        public InvalidUsernameException(string message) : base(message) { }
    }
}

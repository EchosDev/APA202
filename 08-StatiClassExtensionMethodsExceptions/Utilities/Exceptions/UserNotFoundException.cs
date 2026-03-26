using System;
using System.Collections.Generic;
using System.Text;

namespace _08_StatiClassExtensionMethodsExceptions.Utilities.Exceptions
{
    internal class UserNotFoundException : Exception
    {
        private static string _message = "There is no such User in the system.";
        public UserNotFoundException() : base(_message) { }
        public UserNotFoundException(string username) : base($"This {username} does not exist") { }
    }
}

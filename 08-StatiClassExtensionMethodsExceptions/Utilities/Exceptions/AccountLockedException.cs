using System;
using System.Collections.Generic;
using System.Text;

namespace _08_StatiClassExtensionMethodsExceptions.Utilities.Exceptions
{
    internal class AccountLockedException : Exception
    {
        public AccountLockedException() : base("Account has been locked.") { }
    }
}

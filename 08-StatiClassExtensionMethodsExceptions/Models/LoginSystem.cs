using _08_StatiClassExtensionMethodsExceptions.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;

namespace _08_StatiClassExtensionMethodsExceptions.Models
{
    internal class LoginSystem
    {
        private User[] users;
        private static int MaxAttempts = 3;

        public LoginSystem()
        {
            users = new User[]
            {
                new User("admin", "admin123"),
                new User("student", "student123"),
                new User("teacher", "teacher123")
            };
        }

        public void ValidateUsername(string username)
        {
            if (username == null || username.Length < 3)
            {
                throw new InvalidUsernameException();
            }
        }
        public void ValidatePassword(string password)
        {
            if (password == null || password.Length < 6)
            {
                throw new InvalidPasswordException();
            }
        }

        private User? FindUser(string username)
        {
            username = username.ToLower().Trim();
            foreach (User user in users)
            {
                if (username == user.Username.ToLower().Trim()) return user;
            }

            return null;
        }

        public bool Login(string username, string password)
        {
            ValidateUsername(username);
            ValidatePassword(password);
            User user = FindUser(username);

            if (user == null) throw new UserNotFoundException();
            if (user.IsLocked) throw new AccountLockedException();
            if (password == user.Password)
            {
                user.FailedAttempts = 0;
                Console.WriteLine($"Login successful! Welcome, {username}!");
                return true;
            }
            else
            {
                user.FailedAttempts++;
                int attemptsLeft = MaxAttempts - user.FailedAttempts;
                if (attemptsLeft > 0)
                {
                    throw new IncorrectPasswordException(attemptsLeft);
                }
                else
                {
                    user.IsLocked = true;
                    throw new AccountLockedException();
                }
            }
        }
    }
}

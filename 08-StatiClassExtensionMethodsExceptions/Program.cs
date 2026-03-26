using _08_StatiClassExtensionMethodsExceptions.Models;
using _08_StatiClassExtensionMethodsExceptions.Utilities.Exceptions;

namespace _08_StatiClassExtensionMethodsExceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LoginSystem system = new LoginSystem();

            while (true)
            {
                try
                {
                    Console.Write("Enter username: ");
                    string username = Console.ReadLine();

                    Console.Write("Enter password: ");
                    string password = Console.ReadLine();

                    bool isLoginSuccesfull = system.Login(username, password);

                    if (isLoginSuccesfull) break;
                }
                catch (InvalidUsernameException ex)
                {
                    Console.WriteLine($"ERROR {ex.Message}");
                }
                catch (InvalidPasswordException ex)
                {
                    Console.WriteLine($"ERROR {ex.Message}");
                }
                catch (UserNotFoundException ex)
                {
                    Console.WriteLine($"ERROR {ex.Message}");
                }
                catch (IncorrectPasswordException ex)
                {
                    Console.WriteLine($"WARNING {ex.Message}");
                }
                catch (AccountLockedException ex)
                {
                    Console.WriteLine($"CRITICAL {ex.Message}");
                    Console.WriteLine("Contact admin.");
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"UNEXPECTED ERROR {ex.Message}");
                }
            }
        }
    }
}

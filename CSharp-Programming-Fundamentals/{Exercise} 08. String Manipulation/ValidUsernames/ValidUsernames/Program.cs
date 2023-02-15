using System;
using System.Security;

namespace ValidUsernames
{
    class ValidUsernames
    {
        static void Main()
        {
            string[] usernames = Console.ReadLine().Split(", ");

            foreach (var currentUsername in usernames)
            {
                if (currentUsername.Length >= 3 && currentUsername.Length <= 16)
                {
                    bool isValid = true;

                    foreach (char symbol in currentUsername)
                    {
                        if (!(char.IsLetterOrDigit(symbol) || symbol == '-' || symbol == '_'))
                        {
                            isValid = false;
                            break;
                        }
                    }

                    if (isValid) Console.WriteLine(currentUsername);
                }
            }
        }
    }
}
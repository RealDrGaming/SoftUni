using System;

namespace Login
{
    class Program
    {
        static void Main()
        {
            string username = Console.ReadLine();

            char[] usernameLetters = username.ToCharArray();

            string usernameBackwards = null;

            bool isUserLogged = false;

            for (int i = username.Length - 1; i >= 0; i--) 
            {
                usernameBackwards = usernameBackwards + username[i];
            }

            for (int i = 1; i <= 4; i++)
            {
                string password = Console.ReadLine();

                if (password == usernameBackwards)
                {
                    Console.WriteLine($"User {username} logged in."); 
                    isUserLogged = true;
                    break;
                }
                else if(i != 4) Console.WriteLine("Incorrect password. Try again.");
            }

            if (!isUserLogged) Console.WriteLine($"User {username} blocked!");
        }
    }
}
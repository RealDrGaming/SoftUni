using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Loader;

namespace ValidUsernames
{
    class CaesarCipher
    {
        static void Main()
        {
            string line = Console.ReadLine();
            char[] lineCharred = line.ToCharArray();

            for (int i = 0; i < line.Length; i++)
            {
                lineCharred[i] = (char)(lineCharred[i] + 3);
            }

            Console.WriteLine(String.Join("", lineCharred));
        }
    }
}
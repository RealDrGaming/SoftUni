using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Loader;
using System.ComponentModel.DataAnnotations;

namespace ValidUsernames
{
    class ReplaceRepeatingChars
    {
        static void Main()
        {
            string line = Console.ReadLine();
            
            char prevChar = line[0];
            Console.Write(prevChar);

            for (int i = 1; i < line.Length; i++)
            {
                char currChar = line[i];

                if (prevChar != currChar)
                {
                    prevChar = currChar;
                    Console.Write(prevChar);
                }
            }
        }
    }
}
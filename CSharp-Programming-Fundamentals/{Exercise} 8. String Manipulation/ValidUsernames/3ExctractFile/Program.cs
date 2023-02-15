using System;
using System.Linq;
using System.Collections.Generic;

namespace ValidUsernames
{
    class ExtractFile
    {
        static void Main()
        {
            string[] line = Console.ReadLine().Split(new char[] { '\\', '.' });

            Console.WriteLine($"File name: {line[line.Length - 2]}");
            Console.WriteLine($"File extension: {line[line.Length - 1]}");
        }
    }
}
using System;

namespace IntegerOperations
{
    class TriplesOfLatinLetters
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                char firstChar = (char)('a' + i);

                for (int j = 0; j < n; j++)
                {
                    char secondChar = (char)('a' + j);

                    for (int k = 0; k < n; k++)
                    {
                        char thirdChar = (char)('a' + k);

                        Console.Write($"{firstChar}{secondChar}{thirdChar}");
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
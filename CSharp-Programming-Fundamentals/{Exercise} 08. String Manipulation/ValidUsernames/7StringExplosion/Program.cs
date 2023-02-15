using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ValidUsernames
{
    class StringExplosion
    {
        static void Main()
        {
            string line = Console.ReadLine();

            int bombPower = 0;

            for (int i = 0; i < line.Length; i++)
            {
                if (bombPower > 0 && line[i] != '>')
                {
                    line = line.Remove(i, 1);
                    bombPower--;
                    i--;
                }
                else if (line[i] == '>')
                {
                    bombPower += int.Parse(line[i + 1].ToString());
                }
            }

            Console.WriteLine(line);
        }
    }
}
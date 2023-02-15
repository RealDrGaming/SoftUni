using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Loader;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ValidUsernames
{
    class MultiplyBigNumber
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int multiplier = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();
            int reminder = 0;

            if (input == "0" || multiplier == 0)
            {
                Console.WriteLine(0);
                return;
            }

            for (int i = input.Length - 1; i >= 0; i--)
            {
                int currDigit = int.Parse(input[i].ToString());
                int product = currDigit * multiplier + reminder;

                int result = product % 10;
                reminder = product / 10;

                sb.Insert(0, result);
            }

            if (reminder > 0)
            {
                sb.Insert(0, reminder);
            }

            Console.WriteLine(sb);
        }
    }
}
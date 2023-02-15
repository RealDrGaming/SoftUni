using System;
using System.Linq;
using System.Collections.Generic;

namespace CountCharsInAString 
{
    public class CountCharsInAString 
    {
        public static void Main() 
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();

            string line = string.Join("", Console.ReadLine().Split(" "));

            foreach (char symbol in line)
            {
                if (!dic.ContainsKey(symbol))
                {
                    dic.Add(symbol, 0);
                }

                dic[symbol] += 1;
            }

            foreach (var item in dic)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
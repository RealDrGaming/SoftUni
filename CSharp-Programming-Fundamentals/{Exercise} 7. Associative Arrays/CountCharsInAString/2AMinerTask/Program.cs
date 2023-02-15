using System;
using System.Linq;
using System.Collections.Generic;

namespace CountCharsInAString
{
    public class AMinerTask
    {
        public static void Main()
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();

            string resource = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            while (resource != "stop")
            {
                if (dic.ContainsKey(resource))
                {
                    dic[resource] += quantity;
                }
                else
                {
                    dic[resource] = quantity;
                }

                resource = Console.ReadLine();

                if (resource != "stop")
                {
                    quantity = int.Parse(Console.ReadLine());
                }
            }

            foreach (var item in dic)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;

namespace CountCharsInAString
{
    public class Orders
    {
        public static void Main()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            string[] line = Console.ReadLine().Split(" ");

            string name = line[0];
            double price = double.Parse(line[1]);
            double quantity = double.Parse(line[2]);

            while (name != "buy")
            {
                if (dic.ContainsKey(name))
                {
                    string oldValue = dic[name];

                    double[] dicSplit = oldValue.Split('*').Select(x => double.Parse(x)).ToArray();

                    dic[name] = $"{quantity + dicSplit[0]}*{price}";
                }
                else
                {
                    dic.Add(name, $"{quantity}*{price}");
                }

                line = Console.ReadLine().Split(" ");

                name = line[0];

                if (name != "buy")
                {
                    price = double.Parse(line[1]);
                    quantity = double.Parse(line[2]);
                }
            }

            foreach (var item in dic)
            {
                double[] numbersSplit = item.Value.Split('*').Select(x => double.Parse(x)).ToArray();

                double totalPrice = numbersSplit[0] * numbersSplit[1];

                Console.WriteLine($"{item.Key} -> {totalPrice:F2}");
            }
        }
    }
}
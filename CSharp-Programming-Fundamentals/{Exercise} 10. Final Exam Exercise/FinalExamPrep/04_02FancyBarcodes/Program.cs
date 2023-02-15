using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace FinalExamPrep
{
    class FancyBarcodes
    {
        static void Main()
        {
            string pattern = @"\@\#+(?<barcode>[A-Z][A-Za-z0-9]{4,}[A-Z])\@\#+";
            Regex regex = new Regex(pattern);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Match match = regex.Match(input);

                if (match.Success)
                {
                    string barcode = match.Groups["barcode"].Value;
                    var productGroup = new StringBuilder();

                    foreach (char symbol in barcode)
                    {
                        if (char.IsDigit(symbol))
                        {
                            productGroup.Append(symbol);
                        }
                    }

                    if (productGroup.Length > 0)
                    {
                        Console.WriteLine($"Product group: {productGroup}");
                    }
                    else
                    {
                        Console.WriteLine($"Product group: 00");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
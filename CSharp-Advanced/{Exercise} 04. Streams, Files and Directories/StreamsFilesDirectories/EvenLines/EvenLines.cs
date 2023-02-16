using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace EvenLines;

public class EvenLines
{
    static void Main()
    {
        string inputFilePath = @"..\..\..\text.txt";

        Console.WriteLine(ProcessLines(inputFilePath));
    }

    public static string ProcessLines(string inputFilePath)
    {
        StringBuilder sb = new();

        using StreamReader reader = new StreamReader(inputFilePath);

        int count = 0;

        string toReturn = string.Empty;

        while (toReturn != null)
        {
            toReturn = reader.ReadLine();

            if (count % 2 == 0)
            {
                string replacedSymbols = ReplaceSymbols(toReturn);
                string reversedWords = ReverseWords(replacedSymbols);

                sb.Append(reversedWords);
            }
            count++;
        }

        return sb.ToString();
    }

    private static string ReplaceSymbols(string toReturn)
    {
        StringBuilder sb = new(toReturn);

        string[] symbolsToReplace = { "-", ",", ".", "!", "?" };

        foreach (var symbol in symbolsToReplace)
        {
            sb.Replace(symbol, "@");
        }

        return sb.ToString();
    }
    private static string ReverseWords(string replacedSymbols)
    {
        string[] reversedWords = replacedSymbols.Split(' ').Reverse().ToArray();

        return string.Join(" ", reversedWords);
    }
}
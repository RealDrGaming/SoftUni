using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace FinalExamPrep
{
    class Piece
    {
        public string Composer { get; set; }
        public string Key { get; set; }
    }

    class ThePianist
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Piece> pieces = new Dictionary<string, Piece>();

            for (int i = 0; i < n; i++)
            {
                string[] args = Console.ReadLine().Split('|');

                if (!pieces.ContainsKey(args[0]))
                {
                    Piece piece = new Piece();
                    piece.Composer = args[1];
                    piece.Key = args[2];

                    pieces.Add(args[0], piece);
                }
            }

            string command = Console.ReadLine();

            while (command != "Stop")
            {
                string[] commandInfo = command.Split('|');
                string commandName = commandInfo[0];
                string pieceName = commandInfo[1];

                if (commandName == "Add")
                {
                    if (!pieces.ContainsKey(pieceName))
                    {
                        Piece piece = new Piece();
                        piece.Composer = commandInfo[2];
                        piece.Key = commandInfo[3];

                        pieces.Add(pieceName, piece);

                        Console.WriteLine($"{pieceName} by {commandInfo[2]} in {commandInfo[3]} added to the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{pieceName} is already in the collection!");
                    }
                }
                else if (commandName == "Remove")
                {
                    if (pieces.ContainsKey(pieceName))
                    {
                        pieces.Remove(pieceName);

                        Console.WriteLine($"Successfully removed {pieceName}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
                    }
                }
                else if (commandName == "ChangeKey")
                {
                    if (pieces.ContainsKey(pieceName))
                    {

                        pieces[pieceName].Key = commandInfo[2];

                        Console.WriteLine($"Changed the key of {pieceName} to {commandInfo[2]}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var item in pieces)
            {
                Console.WriteLine($"{item.Key} -> Composer: {item.Value.Composer}, Key: {item.Value.Key}");
            }
        }
    }
}
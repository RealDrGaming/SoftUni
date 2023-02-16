using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;

namespace HelpAMole 
{
    public class HelpAMole 
    {
        static void Main() 
        {
            int size = int.Parse(Console.ReadLine());

            string[,] playingField = new string[size, size];

            int moleRow = 0;
            int moleCol = 0;

            int firstTunnelRow = 0;
            int firstTunnelCol = 0;
            bool isFirstTunnelFound = false;

            int secondTunnelRow = 0;
            int secondTunnelCol = 0;

            int points = 0;

            for (int row = 0; row < playingField.GetLength(0); row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < playingField.GetLength(1); col++)
                {
                    playingField[row, col] = rowData[col].ToString();

                    if (rowData[col].ToString() == "M")
                    {
                        moleRow = row;
                        moleCol = col;
                    }
                    else if (rowData[col].ToString() == "S" && !isFirstTunnelFound) 
                    {
                        firstTunnelRow = row;
                        firstTunnelCol = col;

                        isFirstTunnelFound = true;
                    }
                    else if (rowData[col].ToString() == "S")
                    {
                        secondTunnelRow = row;
                        secondTunnelCol = col;
                    }
                }
            }

            playingField[moleRow, moleCol] = "-";

            string command = Console.ReadLine();

            while (command != "End" && points < 25)
            {
                if (command == "up" && moleRow - 1 >= 0 && moleRow - 1 < playingField.GetLength(0))
                {
                    moleRow--;
                }
                else if (command == "down" && moleRow + 1 >= 0 && moleRow + 1 < playingField.GetLength(0))
                {
                    moleRow++;
                }
                else if (command == "left" && moleCol - 1 >= 0 && moleCol - 1 < playingField.GetLength(1))
                {
                    moleCol--;
                }
                else if (command == "right" && moleCol + 1 >= 0 && moleCol + 1 < playingField.GetLength(1))
                {
                    moleCol++;
                }
                else
                {
                    Console.WriteLine("Don't try to escape the playing field!");
                }

                if (playingField[moleRow, moleCol] == "S")
                {
                    if (moleRow == firstTunnelRow && moleCol == firstTunnelCol)
                    {
                        playingField[moleRow, moleCol] = "-";

                        moleRow = secondTunnelRow;
                        moleCol = secondTunnelCol;

                        playingField[moleRow, moleCol] = "-";
                    }
                    else if (moleRow == secondTunnelRow && moleCol == secondTunnelCol)
                    {
                        playingField[moleRow, moleCol] = "-";

                        moleRow = firstTunnelRow;
                        moleCol = firstTunnelCol;

                        playingField[moleRow, moleCol] = "-";
                    }

                    points -= 3;
                }
                else if (playingField[moleRow, moleCol] == "-")
                {

                }
                else
                {
                    points += int.Parse(playingField[moleRow, moleCol]);
                    playingField[moleRow, moleCol] = "-";
                }

                command = Console.ReadLine();
            }

            playingField[moleRow, moleCol] = "M";

            if (points >= 25)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {points} points.");
            }

            for (int row = 0; row < playingField.GetLength(0); row++)
            {
                for (int col = 0; col < playingField.GetLength(1); col++)
                {
                    Console.Write($"{playingField[row, col]}");
                }

                Console.WriteLine();
            }
        }
    }
}
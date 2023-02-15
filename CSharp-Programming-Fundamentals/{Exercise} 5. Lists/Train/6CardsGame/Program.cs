using System;
using System.Collections.Generic;
using System.Linq;

namespace Train
{
    class CardsGame
    {
        static void Main()
        {
            List<int> hand1 = new List<int>();

            hand1 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> hand2 = new List<int>();

            hand2 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            bool isPlayer1Won = false;
            bool isPlayer2Won = false;

            int handLength = hand1.Count;

            while (isPlayer1Won != true && isPlayer2Won != true)
            {
                for (int i = 0; i < handLength; i++)
                {
                    if (hand1.Count == 0)
                    {
                        isPlayer2Won = true;
                        break;
                    }
                    else if (hand2.Count == 0)
                    {
                        isPlayer1Won = true;
                        break;
                    }

                    int hand1Card = hand1[0];
                    int hand2Card = hand2[0];

                    if (hand1Card > hand2Card)
                    {
                        hand1.RemoveAt(0);
                        hand1.Add(hand1Card);
                        hand1.Add(hand2Card);

                        hand2.RemoveAt(0);
                    }
                    else if (hand1Card == hand2Card)
                    {
                        hand1.RemoveAt(0);

                        hand2.RemoveAt(0);
                    }
                    else if (hand1Card < hand2Card)
                    {
                        hand2.RemoveAt(0);
                        hand2.Add(hand2Card);
                        hand2.Add(hand1Card);

                        hand1.RemoveAt(0);
                    }
                }
            }

            int sum = 0;

            if (isPlayer1Won == true)
            {
                sum = hand1.Sum();

                Console.WriteLine($"First player wins! Sum: {sum}");
            }
            else if (isPlayer2Won == true)
            {
                sum = hand2.Sum();

                Console.WriteLine($"Second player wins! Sum: {sum}");
            }
        }
    }
}
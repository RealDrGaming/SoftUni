using System;

namespace VendingMachine
{
    class Program
    {
        static void Main()
        {
            string inputLine = null;

            double balance = 0;

            while (inputLine != "Start") 
            {
                inputLine = Console.ReadLine();

                if (inputLine != "Start")
                {
                    switch (inputLine)
                    {
                        case "0.1":
                            balance += 0.1;
                            break;
                        case "0.2":
                            balance += 0.2;
                            break;
                        case "0.5":
                            balance += 0.5;
                            break;
                        case "1":
                            balance += 1;
                            break;
                        case "2":
                            balance += 2;
                            break;
                        default:
                            Console.WriteLine($"Cannot accept {inputLine}");
                            break;
                    }
                }
            }

            while (inputLine != "End")
            {
                inputLine = Console.ReadLine();

                if (inputLine != "End")
                {
                    if (inputLine == "Nuts")
                    {
                        if (balance >= 2)
                        {
                            balance -= 2;
                            Console.WriteLine("Purchased nuts"); //PROBLEM MAY BE HERE
                        }
                        else Console.WriteLine("Sorry, not enough money");
                    }
                    else if (inputLine == "Water")
                    {
                        if (balance >= 0.7)
                        {
                            balance -= 0.7;
                            Console.WriteLine("Purchased water"); //PROBLEM MAY BE HERE
                        }
                        else Console.WriteLine("Sorry, not enough money");
                    }
                    else if (inputLine == "Crisps")
                    {
                        if (balance >= 1.5)
                        {
                            balance -= 1.5;
                            Console.WriteLine("Purchased crisps"); //PROBLEM MAY BE HERE
                        }
                        else Console.WriteLine("Sorry, not enough money");
                    }
                    else if (inputLine == "Soda")
                    {
                        if (balance >= 0.8)
                        {
                            balance -= 0.8;
                            Console.WriteLine("Purchased soda"); //PROBLEM MAY BE HERE
                        }
                        else Console.WriteLine("Sorry, not enough money");
                    }
                    else if (inputLine == "Coke")
                    {
                        if (balance >= 1)
                        {
                            balance -= 1;
                            Console.WriteLine("Purchased coke"); //PROBLEM MAY BE HERE
                        }
                        else Console.WriteLine("Sorry, not enough money");
                    }

                    if (inputLine != "Nuts" && inputLine != "Water" && inputLine != "Crisps" && inputLine != "Soda" && inputLine != "Coke")
                    {
                        Console.WriteLine("Invalid product");
                    }
                }
            }

            Console.WriteLine($"Change: {balance:F2}");
        }
    }
}
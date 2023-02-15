using System;
using System.Linq;
using System.Collections.Generic;

namespace CountCharsInAString
{
    public class SoftUniParking
    {
        public static void Main()
        {
            Dictionary<string, string> parkingUsers = new Dictionary<string, string>();

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] command = Console.ReadLine().Split(" ");

                string commandInfo = command[0];
                string username = command[1];

                if (commandInfo == "register")
                {
                    string licensePlateNumber = command[2];

                    if (parkingUsers.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {parkingUsers[username]}");
                    }
                    else
                    {
                        parkingUsers.Add(username, licensePlateNumber);
                        Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
                    }
                }
                else if (commandInfo == "unregister")
                {
                    if (parkingUsers.ContainsKey(username))
                    {
                        parkingUsers.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                }
            }

            foreach (var item in parkingUsers)
            {
                Console.WriteLine($"{item.Key} => {item.Value:F2}");
            }
        }
    }
}
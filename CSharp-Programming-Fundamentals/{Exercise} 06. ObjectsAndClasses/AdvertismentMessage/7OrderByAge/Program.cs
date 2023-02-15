using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Net.Mail;

namespace AdvertismentMessage
{
    class OrderByAge
    {
        static void Main()
        {
            List<Person> people = new List<Person>();

            string commandLine = Console.ReadLine();

            while (commandLine != "End")
            {
                string[] lineSplit = commandLine
                    .Split(" ")
                    .ToArray();

                for (int i = 0; i < people.Count; i++)
                {
                    if (lineSplit[1] == people[i].ID)
                    {
                        people[i].Name = lineSplit[0];
                        people[i].Age = int.Parse(lineSplit[2]);
                    }
                }

                Person person = new Person
                {
                    Name = lineSplit[0],
                    ID = lineSplit[1],
                    Age = int.Parse(lineSplit[2]),
                };
                people.Add(person);

                commandLine = Console.ReadLine();
            }

            people = people.OrderBy(x => x.Age).ToList();
            //people.Reverse();

            for (int i = 0; i < people.Count; i++)
            {
                Console.WriteLine($"{people[i].Name} with ID: {people[i].ID} is {people[i].Age} years old.");
            }
        }
    }

    class Person
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }
    }
}
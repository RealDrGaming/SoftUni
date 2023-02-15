using System;

namespace IntegerOperations
{
    class Elevator
    {
        static void Main()
        {
            int people = int.Parse(Console.ReadLine());
            int elevatorCapacity = int.Parse(Console.ReadLine());

            int courses = people / elevatorCapacity;
            if (people % elevatorCapacity != 0) courses++;

            Console.WriteLine(courses);
        }
    }
}
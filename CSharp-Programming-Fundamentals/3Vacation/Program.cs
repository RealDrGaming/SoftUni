using System;

namespace Vacation
{
    class Program
    {
        static void Main()
        {
            int peopleCount = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string dayOfStay = Console.ReadLine();

            double pricePerPerson = 0;

            double totalPrice = 0;

            switch (groupType) 
            {
                case "Students":
                    if (dayOfStay == "Friday") pricePerPerson = 8.45;
                    else if (dayOfStay == "Saturday") pricePerPerson = 9.80;
                    else if (dayOfStay == "Sunday") pricePerPerson = 10.46;
                    break;

                case "Business":
                    if (dayOfStay == "Friday") pricePerPerson = 10.90;
                    else if (dayOfStay == "Saturday") pricePerPerson = 15.60;
                    else if (dayOfStay == "Sunday") pricePerPerson = 16;
                    break;

                case "Regular":
                    if (dayOfStay == "Friday") pricePerPerson = 15;
                    else if (dayOfStay == "Saturday") pricePerPerson = 20;
                    else if (dayOfStay == "Sunday") pricePerPerson = 22.50;
                    break;
                default:
                    Console.WriteLine("Impossible");
                    break;
            }

            totalPrice = pricePerPerson * peopleCount;

            if (groupType == "Students" && peopleCount >= 30) totalPrice *= 0.85;

            if (groupType == "Business" && peopleCount >= 100) totalPrice -= pricePerPerson * 10;

            if (groupType == "Regular" && peopleCount >= 10 && peopleCount <= 20) totalPrice *= 0.95;

            Console.WriteLine($"Total price: {totalPrice:F2}");
        }
    }
}
using System;
using System.Linq;
using System.Collections.Generic;

namespace AdvertismentMessage
{
    class AdvertismentMessage
    {
        static void Main()
        {
            int requiredMessages = int.Parse(Console.ReadLine());

            for (int i = 1; i <= requiredMessages; i++)
            {
                Message message = new Message();
                message.PrintMessage();
            }
        }
    }

    class Message
    {
        public string Phrase { get; set; }
        public string Satisfaction { get; set; }
        public string Author { get; set; }
        public string City { get; set; }

        public void PrintMessage() 
        {
            List<string> phrases = new List<string>
            {
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product."
            };

            List<string> satisfactions = new List<string>
            {
                "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"
            };

            List<string> authors = new List<string>
            {
                "Diana",
                "Petya",
                "Stella",
                "Elena",
                "Katya",
                "Iva",
                "Annie",
                "Eva"
            };

            List<string> cities = new List<string>
            {
                "Burgas",
                "Sofia",
                "Plovdiv",
                "Varna",
                "Ruse"
            };

            Random random = new Random();

            int randomPhrase = random.Next(0, phrases.Count);
            int randomSatisfaction = random.Next(0, satisfactions.Count);
            int randomAuthor = random.Next(0, authors.Count);
            int randomCity = random.Next(0, cities.Count);

            Phrase = phrases[randomPhrase];
            Satisfaction = satisfactions[randomSatisfaction];
            Author = authors[randomAuthor];
            City = cities[randomCity];

            Console.WriteLine($"{Phrase} {Satisfaction} {Author} – {City}.");
        }
    }
}
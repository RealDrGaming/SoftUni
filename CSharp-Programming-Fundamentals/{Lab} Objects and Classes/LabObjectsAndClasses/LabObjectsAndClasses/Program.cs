using LabObjectsAndClasses;
using System;

namespace LabObjecstsAndClasses
{
    class LabObjectsAndClasses 
    {
        static void Main() 
        {
            Dog dog = new Dog
            {
                Name = "Sharo",
                Breed = "Golden Retriever",
                Age = 7,
            };

            //both do the same

            //dog.Name = "Sharo";
            //dog.Breed = "Golden Retriever";
            //dog.Age = 7;
            //dog.Bark();

            Console.WriteLine(dog.Name);
            Console.WriteLine(dog.Breed);
            Console.WriteLine(dog.Age);
        }
    }
}
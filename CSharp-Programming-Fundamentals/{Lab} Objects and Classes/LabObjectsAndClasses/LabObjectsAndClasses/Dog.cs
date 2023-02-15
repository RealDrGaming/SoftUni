using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabObjectsAndClasses
{
    public class Dog
    {
        public string Breed { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public void Bark() 
        {
            Console.WriteLine("woof woof");
        }
    }
}

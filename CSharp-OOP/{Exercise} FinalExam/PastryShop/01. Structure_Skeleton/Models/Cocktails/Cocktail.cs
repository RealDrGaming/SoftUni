using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails
{
    public class Cocktail : ICocktail
    {
        public Cocktail(string cocktailName, string size, double price)
        {
            Name = cocktailName;
            Size = size;
            Price = price;
        }

        private string name;

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }

                name = value;
            }
        }

        public string Size { get; private set; }

        private double price;

        public double Price
        {
            get
            {
                if (Size == "Middle") return (price * 2) / 3;
                else if (Size == "Small") return price / 3;
                else return price; // If size isn't Middle or Small, then it's definitely Large
            }
            private set { price = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{name} ({Size}) - {price:f2} lv");

            return sb.ToString().TrimEnd();
        }
    }
}

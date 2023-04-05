using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Delicacies
{
    public class Delicacy : IDelicacy
    {
        public Delicacy(string delicacyName, double price)
        {
            Name = delicacyName;
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


        public double Price { get; private set; }

        public override string ToString()
        {
			StringBuilder sb = new StringBuilder();

			sb.AppendLine($"{name} - {this.Price:f2} lv");

			return sb.ToString().TrimEnd();
        }
    }
}
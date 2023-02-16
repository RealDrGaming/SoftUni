using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading;

namespace ShoeStore
{
    public class ShoeStore
    {
        public ShoeStore(string name, int storageCapacity)
        {
            Name = name;
            StorageCapacity = storageCapacity;
            Shoes = new List<Shoe>();
        }

        public string Name { get; set; }
        public int StorageCapacity { get; set; }
        public List<Shoe> Shoes { get; set; }
        public int Count { get { return Shoes.Count; } }

        public string AddShoe(Shoe shoe)
        {
            if (StorageCapacity == Shoes.Count)
            {
                return "No more space in the storage room.";
            }

            Shoes.Add(shoe);
            return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
        }

        public int RemoveShoes(string material)
        {
            int removedShoes = 0;

            for (int i = 0; i < Shoes.Count; i++)
            {
                if (Shoes[i].Material == material.ToLower())
                {
                    Shoes.RemoveAt(i--);
                    removedShoes++;
                }
            }

            return removedShoes;
        }

        public List<Shoe> GetShoesByType(string type)
        {
            List<Shoe> shoesOfType = new List<Shoe>();

            foreach (var shoe in Shoes)
            {
                if (shoe.Type == type.ToLower())
                {
                    shoesOfType.Add(shoe);
                }
            }

            return shoesOfType;
        }

        public Shoe GetShoeBySize(double size)
        {
            return Shoes.FirstOrDefault(s => s.Size == size);
        }

        public string StockList(double size, string type)
        {
            List<Shoe> matchingShoes = new List<Shoe>();

            foreach (var shoe in Shoes)
            {
                if (shoe.Size == size && shoe.Type == type)
                {
                    matchingShoes.Add(shoe);
                }
            }

            if (matchingShoes.Count == 0)
            {
                return "No matches found!";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Stock list for size {size} - {type} shoes:");

                foreach (var shoe in matchingShoes)
                {
                    sb.AppendLine(shoe.ToString());
                }

                return sb.ToString().TrimEnd();
            }
        }
    }
}

using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        BoothRepository booths = new BoothRepository();

        public string AddBooth(int capacity)
        {
            Booth booth = new Booth(booths.Models.Count + 1, capacity);
            booths.AddModel(booth);

            return string.Format(OutputMessages.NewBoothAdded, booth.BoothId, capacity);
        }
        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            IDelicacy delicacy;

            switch (delicacyTypeName)
            {
                case nameof(Gingerbread):
                    delicacy = new Gingerbread(delicacyName);
                    break;
                case nameof(Stolen):
                    delicacy = new Stolen(delicacyName);
                    break;
                default: return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            if (booths.Models.Any(b => b.DelicacyMenu.Models.Any(d => d.Name == delicacyName)))
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }

            booths.Models.FirstOrDefault(b => b.BoothId == boothId).DelicacyMenu.AddModel(delicacy);
            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            ICocktail cocktail;

            if (size != "Small" && size != "Middle" && size != "Large")
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }

            switch (cocktailTypeName)
            {
                case nameof(MulledWine):
                    cocktail = new MulledWine(cocktailName, size);
                    break;
                case nameof(Hibernation):
                    cocktail = new Hibernation(cocktailName, size);
                    break;
                default: return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            if (booths.Models.Any(b => b.CocktailMenu.Models.Any(c => c.Name == cocktailName && c.Size == size)))
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            booths.Models.FirstOrDefault(b => b.BoothId == boothId).CocktailMenu.AddModel(cocktail);
            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }
        public string ReserveBooth(int countOfPeople)
        {
            var availableBooth = booths.Models
                .Where(b => b.IsReserved == false && b.Capacity >= countOfPeople)
                .OrderBy(b => b.Capacity)
                .ThenByDescending(b => b.BoothId)
                .FirstOrDefault();

            if (availableBooth == null)
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            availableBooth.ChangeStatus();

            return string.Format(OutputMessages.BoothReservedSuccessfully, availableBooth.BoothId, countOfPeople);
        }
        public string TryOrder(int boothId, string order)
        {
            string[] tokens = order.Split("/", StringSplitOptions.RemoveEmptyEntries);

            string itemTypeName = tokens[0];
            string itemName = tokens[1];
            int countOfOrderedPieces = int.Parse(tokens[2]);
            string size = string.Empty;
            if (tokens.Length == 4) size = tokens[3];

            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            if (itemTypeName != nameof(Gingerbread) && itemTypeName != nameof(Stolen) && itemTypeName != nameof(MulledWine) && itemTypeName != nameof(Hibernation))
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }

            if (itemTypeName == nameof(Gingerbread) || itemTypeName == nameof(Stolen))
            {
                if (!booth.DelicacyMenu.Models.Any(d => d.Name == itemName && d.GetType().Name == itemTypeName))
                {
                    return string.Format(OutputMessages.DelicacyStillNotAdded, itemTypeName, itemName);
                }
            }

            if (itemTypeName == nameof(MulledWine) || itemTypeName == nameof(Hibernation))
            {
                if (!booth.CocktailMenu.Models.Any(d => d.Name == itemName && d.GetType().Name == itemTypeName))
                {
                    return string.Format(OutputMessages.CocktailStillNotAdded, itemTypeName, itemName);
                }
            }

            if (itemTypeName == nameof(Gingerbread))
            {
                IDelicacy delicacy = new Gingerbread(itemName);
                booth.UpdateCurrentBill(countOfOrderedPieces * delicacy.Price);
            }
            else if (itemTypeName == nameof(Stolen))
            {
                IDelicacy delicacy = new Stolen(itemName);
                booth.UpdateCurrentBill(countOfOrderedPieces * delicacy.Price);
            }



            if (itemTypeName == nameof(MulledWine) || itemTypeName == nameof(Hibernation))
            {
                if (!booth.CocktailMenu.Models.Any(d => d.Name == itemName && d.GetType().Name == itemTypeName && d.Size == size))
                {
                    return string.Format(OutputMessages.CocktailStillNotAdded, size, itemName);
                }
            }

            if (itemTypeName == nameof(MulledWine))
            {
                ICocktail cocktail = new MulledWine(itemName, size);
                booth.UpdateCurrentBill(countOfOrderedPieces * cocktail.Price);
            }
            else if (itemTypeName == nameof(Hibernation))
            {
                ICocktail cocktail = new Hibernation(itemName, size);
                booth.UpdateCurrentBill(countOfOrderedPieces * cocktail.Price);
            }

            


            return string.Format(OutputMessages.SuccessfullyOrdered, booth.BoothId, countOfOrderedPieces, itemName);
        }
        public string LeaveBooth(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Bill {booth.CurrentBill:f2} lv");
            sb.AppendLine($"Booth {boothId} is now available!");

            booth.Charge();
            booth.ChangeStatus();

            return sb.ToString().TrimEnd();
        }

        public string BoothReport(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(booth.ToString());

            return sb.ToString().TrimEnd();
        }
    }
}

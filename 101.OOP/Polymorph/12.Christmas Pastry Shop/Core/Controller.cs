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
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private BoothRepository boothRepository;
        private string[] availableItems = { nameof(Hibernation), nameof(MulledWine), nameof(Gingerbread), nameof(Stolen)}; 

        public Controller()
        {
            this.boothRepository = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            int IdBooth = boothRepository.Models.Count + 1;
            boothRepository.AddModel(new Booth(IdBooth, capacity));

            return String.Format(OutputMessages.NewBoothAdded, IdBooth, capacity);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            if (cocktailTypeName != nameof(Hibernation) && cocktailTypeName != nameof(MulledWine))
                return String.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);

            if (size != "Small" && size != "Middle" && size != "Large")
                return String.Format(OutputMessages.InvalidCocktailSize, size);

            IBooth booth = boothRepository.Models.FirstOrDefault(x =>x.BoothId == boothId);
            ICocktail cocktail = booth.CocktailMenu.Models.FirstOrDefault(x =>x.Name == cocktailName && x.Size == size);

            if (cocktail != null)
                return String.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);

            if (cocktailTypeName == nameof(Hibernation))
                cocktail = new Hibernation(cocktailName, size);

            else
                cocktail = new MulledWine(cocktailName, size);

            return String.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            if (delicacyTypeName != nameof(Stolen) && delicacyTypeName != nameof(Gingerbread))
                return String.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);

            IBooth booth = boothRepository.Models.FirstOrDefault(x =>x.BoothId == boothId);
            IDelicacy delicacy = booth.DelicacyMenu.Models.FirstOrDefault(x =>x.Name == delicacyName);

            if (delicacy != null)
                return String.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);

            IDelicacy delicacyNew;

            if (delicacyTypeName == nameof(Stolen))
                delicacyNew = new Stolen(delicacyName);

            else
                delicacyNew = new Gingerbread(delicacyName);

            booth.DelicacyMenu.AddModel(delicacyNew);

            return String.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);

        }

        public string BoothReport(int boothId)
        {
            IBooth booth = boothRepository.Models.FirstOrDefault(x => x.BoothId == boothId);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Booth: { boothId}");
            sb.AppendLine($"Capacity: {booth.Capacity}");
            sb.AppendLine($"Turnover: {booth.Turnover:f2} lv");
            sb.AppendLine("-Cocktail menu:");
            foreach (var cocktail in booth.CocktailMenu.Models)
            {
                sb.AppendLine(cocktail.ToString());
            }
            sb.AppendLine("-Delicacy menu:");

            foreach (var item in booth.DelicacyMenu.Models)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().Trim();
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = boothRepository.Models.First(x =>x.BoothId == boothId);

            booth.Charge();

            booth.ChangeStatus();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Bill {booth.CurrentBill:F2} lv");
            sb.AppendLine($"Booth {boothId} is now available!");

            return sb.ToString().Trim();
        }

        public string ReserveBooth(int countOfPeople)
        {
            IBooth booth = boothRepository.Models
                .Where(x => !x.IsReserved && x.Capacity >= countOfPeople )
                .OrderBy(x => x.Capacity)
                .ThenByDescending(x => x.BoothId)
                .FirstOrDefault();

            if (booth == null)
                return String.Format(OutputMessages.NoAvailableBooth, countOfPeople);

            booth.ChangeStatus();
            return String.Format(OutputMessages.BoothReservedSuccessfully, booth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            string[] inputs = order.Split("/");

            string itemTypeName = inputs[0];
            string itemName = inputs[1];
            int count = int.Parse(inputs[2]);                              

            IBooth booth = boothRepository.Models.First(x => x.BoothId == boothId);

            if (!availableItems.Contains(itemTypeName))
                return String.Format(OutputMessages.NotRecognizedType, itemTypeName);               

            if (itemTypeName == nameof(Hibernation) || itemTypeName == nameof(MulledWine))
            {
                ICocktail cocktail =  booth.CocktailMenu.Models.FirstOrDefault(x => x.Name == itemName && x.Size == inputs[3]);

                if (cocktail == null)
                    return String.Format(OutputMessages.CocktailStillNotAdded, itemTypeName, itemTypeName);

                booth.UpdateCurrentBill(cocktail.Price * count);

            }
            else
            {
                IDelicacy delicacy =  booth.DelicacyMenu.Models.FirstOrDefault(x =>x.Name == itemName);

                if(delicacy == null)
                    return String.Format(OutputMessages.DelicacyStillNotAdded, itemTypeName, itemTypeName);

                booth.UpdateCurrentBill(delicacy.Price * count);
            }

            return String.Format(OutputMessages.SuccessfullyOrdered, boothId, count, itemName);

        }
    }
}

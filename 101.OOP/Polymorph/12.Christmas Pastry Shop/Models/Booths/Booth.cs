using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Booths
{
    internal class Booth : IBooth
    {
        private int boothId;
        private int capacity;
        private double currentBill = 0;
        private double turnover = 0;
        private bool isReserved = false;
        private DelicacyRepository deliveryRepository;
        private CocktailRepository cocktailRepository;

        public Booth(int boothId, int capacity)
        {
            this.BoothId = boothId;
            this.Capacity = capacity;
            deliveryRepository = new DelicacyRepository();
            cocktailRepository = new CocktailRepository();
        }
        

        public int BoothId
        {
            get { return boothId; }
            private set { boothId = value; }
        }        

        public int Capacity
        {
            get { return capacity; }
            private set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                }
                capacity = value; 
            }
        }

        public IRepository<IDelicacy> DelicacyMenu => deliveryRepository;

        public IRepository<ICocktail> CocktailMenu => cocktailRepository;
                

        public double CurrentBill
        {
            get { return currentBill; }
            private set { currentBill = value; }
        }        

        public double Turnover
        {
            get { return turnover; }
            private set { turnover = value; }
        }        

        public bool IsReserved 
        {
            get { return isReserved ; }
            private set { isReserved  = value; }
        }      
        public void ChangeStatus()
        {
            IsReserved = !IsReserved;
        }

        public void Charge()
        {
            Turnover += CurrentBill;
            CurrentBill = 0;
        }

        public void UpdateCurrentBill(double amount)
        {
            CurrentBill += amount;  
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Booth: {BoothId}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Turnover: {Turnover:F2} lv");
            sb.AppendLine("-Cocktail menu:");

            foreach (var cocktail in cocktailRepository.Models)
            {
                sb.AppendLine(cocktail.ToString());
            }

            sb.AppendLine("-Delicacy menu:");

            foreach (var delicacy in deliveryRepository.Models)
            {
                sb.AppendLine(delicacy.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}

using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public interface IWheatService
    {
        void Gain(Wheat wheat);
        void Sell(Person person, Wheat wheat);
        void HireFarmer(Person person, Farmer farmer, Wheat wheat);
        void Harvest(Farmer farmer, Wheat wheat);
        void BuyStorage(Person person, Storage storage, Wheat wheat);
        void BuyMarket(Person person, Markets market, Wheat wheat);
    }
    public class WheatService : IWheatService
    {
        private IItemService _is;
        
        public WheatService(IItemService itemService)
        {
            _is = itemService;
        }
        
        public void Gain(Wheat wheat)
        {
            if (wheat.Total >= wheat.Max)
            {
                wheat.Total = wheat.Max;
            }
            else
            {
                wheat.Total = _is.Gather(wheat.Total, wheat.PerClick);
            }
        }

        public void Sell(Person person, Wheat wheat)
        {
            if (wheat.Total > 0)
            {
                var wheatSold = -1;
                person.Gold = _is.Gather(person.Gold, wheat.Price);
                wheat.Total = _is.Gather(wheat.Total, wheatSold);
            }
        }

        public void HireFarmer(Person person, Farmer farmer, Wheat wheat)
        {
            if(farmer.Cost <= person.Gold)
            {
                person.Gold -= farmer.Cost;
                farmer.Total++;
                farmer.Active = true;
            }
        }

        public void Harvest(Farmer farmer, Wheat wheat)
        {
            if (farmer.Active && wheat.Total < wheat.Max)
            {
                farmer.TotalHarvest = farmer.WheatPerSecond * farmer.Total;
                wheat.Total = _is.Gather(wheat.Total, farmer.TotalHarvest);
            }
        }

        public void BuyStorage(Person person, Storage storage, Wheat wheat)
        {
            if(storage.Cost <= person.Gold)
            {
                person.Gold -= storage.Cost;
                storage.Total++;
                wheat.Max += storage.IncreaseWheatMax;
            }
        }

        public void BuyMarket(Person person, Markets market, Wheat wheat)
        {
            if(market.Cost <= person.Gold)
            {
                person.Gold -= market.Cost;
                market.Total++;
                wheat.Price *= 2;
            }
        }
    }
}

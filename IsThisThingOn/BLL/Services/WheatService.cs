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
        void BuyStorage(Person person, Storage storage, Wheat wheat);
        void BuyMarket(Person person, Markets market, Wheat wheat);
    }
    public class WheatService : IWheatService
    {
        private IItemService _itemService;
        
        public WheatService(IItemService itemService)
        {
            _itemService = itemService;
        }
        
        public void Gain(Wheat wheat)
        {
            wheat.Total = _itemService.Gather(wheat.Total, wheat.PerClick);
            if (wheat.Total > wheat.Max)
            {
                wheat.Total = wheat.Max;
            }
        }

        public void Sell(Person person, Wheat wheat)
        {
            if (wheat.Total > 0)
            {
                wheat.Earn = true;
                person.Gold = _itemService.GainGold(wheat.Price, person.Gold, wheat.Earn);
                wheat.Total = _itemService.Sell(wheat.Total);
            }
        }

        public void HireFarmer(Person person, Farmer farmer, Wheat wheat)
        {
            if(farmer.Cost <= person.Gold)
            {
                person.Gold -= farmer.Cost;
                farmer.Total++;
                farmer.Active = true;
                wheat.PerClick++;
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

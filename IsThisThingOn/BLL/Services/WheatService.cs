using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public interface IWheatService
    {
        void Gain(Person person);
        void Sell(Person person);
        void HireFarmer(Person person);
        void BuyStorage(Person person);
    }
    public class WheatService : IWheatService
    {
        private IItemService _itemService;
        public WheatService(IItemService itemService)
        {
            _itemService = itemService;
        }
        
        public void Gain(Person person)
        {
            person.WheatTotal = _itemService.Gather(person.WheatTotal, person.WheatPerClick);
            if (person.WheatTotal > person.WheatMax)
            {
                person.WheatTotal = person.WheatMax;
            }
        }

        public void Sell(Person person)
        {
            if (person.WheatTotal > 0)
            {
                person.EarnWheat = true;
                person.Gold = _itemService.GainGold(person.WheatPrice, person.Gold, person.EarnWheat);
                person.WheatTotal = _itemService.Sell(person.WheatTotal);
            }
        }

        public void HireFarmer(Person person)
        {
            if(person.FarmerGoldCost <= person.Gold)
            {
                person.Gold -= person.FarmerGoldCost;
                person.Farmers++;
                person.WheatPerClick++;
                person.FarmerActive = true;
            }
        }

        public void BuyStorage(Person person)
        {
            if(person.StorageCost <= person.Gold)
            {
                person.Gold -= person.StorageCost;
                person.StorageUnits++;
                person.WheatMax += person.ChestIncreaseWheatMax;
            }
        }
    }
}

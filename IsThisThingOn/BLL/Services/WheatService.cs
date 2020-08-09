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
            if(person.wheatTotal < person.wheatMax)
            {
                person.wheatTotal = _itemService.Gather(person.wheatTotal);
            }
        }

        public void Sell(Person person)
        {
            if (person.wheatTotal > 0)
            {
                person.EarnWheat = true;
                person.gold = _itemService.GainGold(person.wheatPrice, person.gold, person.EarnWheat);
                person.wheatTotal = _itemService.Sell(person.wheatTotal);
            }
        }
    }
}

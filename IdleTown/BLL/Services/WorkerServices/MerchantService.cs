using BLL.Models;
using BLL.Models.Market;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services.WorkerServices
{
    public interface IMerchantService
    {
        void Hire(Person person, Merchant merchant);
        void SellWheat(Person person, Merchant merchant, Wheat wheat);
        void SellStone(Person person, Merchant merchant, Stone stone);
    }
    public class MerchantService : IMerchantService
    {
        private IItemService _is;
        private ITownsPeopleService _ts;

        public MerchantService(IItemService itemService, ITownsPeopleService townsPeopleService)
        {
            _is = itemService;
            _ts = townsPeopleService;
        }

        public void Hire(Person person, Merchant merchant)
        {
            merchant.Active = _ts.Hire(person.Gold, merchant.Cost);
            person.Gold = _ts.PayForHire(person.Gold, merchant.Cost);
        }

        public void SellWheat(Person person, Merchant merchant, Wheat wheat)
        {
            if (wheat.Total > 0)
            {
                var quantitySold = merchant.WheatQuantitySold * -1;
                person.Gold = _is.Gather(person.Gold, merchant.WheatPrice);
                wheat.Total = _is.Gather(wheat.Total, quantitySold);
            }
        }

        public void SellStone(Person person, Merchant merchant, Stone stone)
        {
            if (stone.Total > 0)
            {
                var quantitySold = merchant.StoneQuantitySold * -1;
                person.Gold = _is.Gather(person.Gold, merchant.WheatPrice);
                stone.Total = _is.Gather(stone.Total, quantitySold);
            }
            stone.Total = _is.Sell(stone.Total, merchant.StoneQuantitySold);
        }
    }
}

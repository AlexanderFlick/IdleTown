using BLL.Models;
using BLL.Models.Market;

namespace BLL.Services.WorkerServices
{
    public interface IMerchantService
    {
        void Hire(Merchant merchant, Wheat wheat);

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

        public void Hire(Merchant merchant, Wheat wheat)
        {
            merchant.Active = _ts.Hire(wheat.Total, merchant.Cost);
            if (merchant.Active)
            {
                wheat.Total = _ts.PayForHire(wheat.Total, merchant.WheatPrice);
            }
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
                person.Gold = _is.Gather(person.Gold, merchant.StonePrice);
                stone.Total = _is.Gather(stone.Total, quantitySold);
            }
        }
    }
}
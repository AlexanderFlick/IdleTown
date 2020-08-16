using BLL.Models;

namespace BLL.Services
{
    public interface IWheatService
    {
        void Gain(Wheat wheat);
        void Sell(Person person, Wheat wheat);
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
            wheat.Total = _is.Gather(wheat.Total, wheat.PerClick);
            wheat.Total = _is.CanNotEarnMoreThanMax(wheat.Total, wheat.Max);
        }

        public void Sell(Person person, Wheat wheat)
        {
            if (wheat.Total > 0)
            {
                var wheatSold = -1 * wheat.Sold;
                person.Gold = _is.Gather(person.Gold, wheat.Price);
                wheat.Total = _is.Gather(wheat.Total, wheatSold);
            }
        }

        public void BuyStorage(Person person, Storage storage, Wheat wheat)
        {
            if (storage.Cost <= person.Gold)
            {
                person.Gold = _is.PayFor(person.Gold, storage.Cost);
                storage.Total = _is.Gather(storage.Total, storage.PerClick);
                wheat.Max = _is.Gather(wheat.Max, storage.IncreaseWheatMax);
            }
        }
        
        public void BuyMarket(Person person, Markets market, Wheat wheat)
        {
            if (market.Cost <= person.Gold)
            {
                person.Gold = _is.PayFor(person.Gold, market.Cost);
                market.Total = _is.Gather(market.Total, market.PerClick);
                wheat.Price = _is.IncreasePriceOnPurchase(market.Multiplier, wheat.Price);
            }
        }
    }
}
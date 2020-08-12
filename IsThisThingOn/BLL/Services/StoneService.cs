using BLL.Models;

namespace BLL.Services
{
    public interface IStoneService
    {
        void Gain(Stone stone);

        void Sell(Person person, Stone stone);
        void HireMiner(Person person, Miner miner);
        void Harvest(Miner miner, Stone stone);
        void BuyWarehouse(Person person, Warehouse warehouse, Stone stone);

    }

    public class StoneService : IStoneService
    {
        private IItemService _is;

        public StoneService(IItemService itemService)
        {
            _is = itemService;
        }

        public void Gain(Stone stone)
        {
            if (stone.Total >= stone.Max)
            {
                stone.Total = stone.Max;
            }
            else
            {
                stone.Total = _is.Gather(stone.Total, stone.PerClick);
            }
        }

        public void Sell(Person person, Stone stone)
        {
            if (stone.Total > 0)
            {
                var stoneSold = -1 * stone.Sold;
                person.Gold = _is.Gather(person.Gold, stone.Price);
                stone.Total = _is.Gather(stone.Total, stoneSold);
            }
        }
        public void HireMiner(Person person, Miner miner)
        {
            if (miner.Cost <= person.Gold)
            {
                person.Gold = _is.PayFor(person.Gold, miner.Cost);
                miner.Total = _is.Gather(miner.Total, miner.PerClick);
                miner.Active = true;
            }
        }

        public void Harvest(Miner miner, Stone stone)
        {
            if (miner.Active && stone.Total < stone.Max)
            {
                miner.TotalHarvest = miner.StonePerSecond * miner.Total;
                stone.Total = _is.Gather(stone.Total, miner.TotalHarvest);
            }
            if (stone.Total > stone.Max)
            {
                stone.Total = stone.Max;
            }
        }

        public void BuyWarehouse(Person person, Warehouse warehouse, Stone stone)
        {
            if (warehouse.Cost <= person.Gold)
            {
                person.Gold = _is.PayFor(person.Gold, warehouse.Cost);
                warehouse.Total = _is.Gather(warehouse.Total, warehouse.PerClick);
                stone.Max = _is.Gather(stone.Max, warehouse.IncreaseStoneMax);
            }
        }

        public void BuyMarket(Person person, Markets market, Stone stone)
        {
            if (market.Cost <= person.Gold)
            {
                person.Gold = _is.PayFor(person.Gold, market.Cost);
                market.Total = _is.Gather(market.Total, market.PerClick);
                stone.Price = _is.IncreasePriceOnPurchase(market.Multiplier, stone.Price);
            }
        }
    }
}
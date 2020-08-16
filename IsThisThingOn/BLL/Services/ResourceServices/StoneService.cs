using BLL.Models;

namespace BLL.Services
{
    public interface IStoneService
    {
        void Gain(Stone stone);
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

        public void BuyWarehouse(Person person, Warehouse warehouse, Stone stone)
        {
            if (warehouse.Cost <= person.Gold)
            {
                person.Gold = _is.PayFor(person.Gold, warehouse.Cost);
                warehouse.Total = _is.Gather(warehouse.Total, warehouse.PerClick);
                stone.Max = _is.Gather(stone.Max, warehouse.IncreaseStoneMax);
            }
        }
    }
}
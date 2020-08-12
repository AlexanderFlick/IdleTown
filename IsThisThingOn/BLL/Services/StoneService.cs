using BLL.Models;

namespace BLL.Services
{
    public interface IStoneService
    {
        void Gain(Stone stone);

        void Sell(Person person, Stone stone);
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
    }
}
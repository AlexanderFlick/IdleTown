using BLL.Models;

namespace BLL.Services.WorkerServices
{
    public interface IMinerService
    {
        void Hire(Person person, Miner miner, Wheat wheat);

        void Harvest(Miner mienr, Stone stone);
    }

    public class MinerService : IMinerService
    {
        private IItemService _is;
        private ITownsPeopleService _ts;

        public MinerService(IItemService itemService, ITownsPeopleService peopleService)
        {
            _is = itemService;
            _ts = peopleService;
        }

        public void Hire(Person person, Miner miner, Wheat wheat)
        {
            if (wheat.Total >= miner.WheatCost)
            {
                miner.Active = _ts.Hire(person.Gold, miner.Cost);
                person.Gold = _ts.PayForHire(person.Gold, miner.Cost);
                wheat.Total = _is.PayFor(wheat.Total, miner.WheatCost);
            }
        }

        public void Harvest(Miner miner, Stone stone)
        {
            if (miner.Active)
            {
                stone.Total = _is.Gather(stone.Total, miner.StonePerSecond);
                stone.Total = _is.CanNotEarnMoreThanMax(stone.Total, stone.Max);
            }
        }
    }
}
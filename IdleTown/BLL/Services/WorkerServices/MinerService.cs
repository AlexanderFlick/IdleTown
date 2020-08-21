using BLL.Models;
using BLL.Models.Resources;

namespace BLL.Services.WorkerServices
{
    public interface IMinerService
    {
        void Hire(Person person, Miner miner, Wheat wheat);

        void Harvest(Miner mienr, Stone stone, Pickaxe pickaxe);
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
            if (wheat.Total >= miner.WheatCost && person.Gold >= miner.Cost)
            {
                miner.Active = _ts.Hire(person.Gold, miner.Cost);
                person.Gold = _ts.PayForHire(person.Gold, miner.Cost);
                wheat.Total = _is.PayFor(wheat.Total, miner.WheatCost);
            }
        }

        public void Harvest(Miner miner, Stone stone, Pickaxe pickaxe)
        {
            if (miner.Active)
            {
                miner.HarvestRate *= pickaxe.HarvestIncrease;
                stone.Total = _is.Gather(stone.Total, miner.HarvestRate);
                stone.Total = _is.CanNotEarnMoreThanMax(stone.Total, stone.Max);
            }
        }
    }
}
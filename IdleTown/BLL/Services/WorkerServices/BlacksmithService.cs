using BLL.Models;
using BLL.Models.Resources;
using BLL.Models.Townspeople;

namespace BLL.Services.WorkerServices
{
    public interface IBlackSmithService
    {
        void Hire(Person person, Blacksmith blacksmith, Wheat wheat, Stone stone, Sickle sickle);

        void UpgradeSickle(Person person, Sickle sickle, Stone stone);
    }

    public class BlacksmithService : IBlackSmithService
    {
        private ITownsPeopleService _ts;
        private IItemService _is;

        public BlacksmithService(IItemService itemService, ITownsPeopleService townsPeopleService)
        {
            _is = itemService;
            _ts = townsPeopleService;
        }

        public void Hire(Person person, Blacksmith blacksmith, Wheat wheat, Stone stone, Sickle sickle)
        {
            blacksmith.Active = CanAffordBlacksmith(person, blacksmith, wheat, stone);
            if (blacksmith.Active)
            {
                PayForBlacksmith(person, blacksmith, wheat, stone);
                sickle.Active = true;
            }
        }

        private bool CanAffordBlacksmith(Person person, Blacksmith blacksmith, Wheat wheat, Stone stone)
        {
            var isActive = blacksmith.Active;
            if (!isActive)
            {
                isActive = _ts.Hire(person.Gold, blacksmith.Cost);
            }
            if (isActive)
            {
                isActive = _ts.Hire(wheat.Total, blacksmith.WheatCost);
            }
            if (isActive)
            {
                isActive = _ts.Hire(stone.Total, blacksmith.StoneCost);
            }
            return isActive;
        }

        private void PayForBlacksmith(Person person, Blacksmith blacksmith, Wheat wheat, Stone stone)
        {
            person.Gold = _is.PayFor(person.Gold, blacksmith.Cost);
            wheat.Total = _is.PayFor(wheat.Total, blacksmith.WheatCost);
            stone.Total = _is.PayFor(stone.Total, blacksmith.StoneCost);
        }

        public void UpgradeSickle(Person person, Sickle sickle, Stone stone)
        {
            sickle.Active = PayForSickle(person, sickle, stone);
            if (sickle.Active)
            {
                IncreaseSickleCost(sickle);
                IncreaseSickleQuality(sickle);
            }
        }

        public bool PayForSickle(Person person, Sickle sickle, Stone stone)
        {
            var active = false;
            if (person.Gold >= sickle.GoldCost && stone.Total >= sickle.StoneCost)
            {
                person.Gold = _is.PayFor(person.Gold, sickle.GoldCost);
                stone.Total = _is.PayFor(stone.Total, sickle.StoneCost);
                active = true;
            }
            return active;
        }

        public void IncreaseSickleCost(Sickle sickle)
        {
            sickle.StoneCost *= 2;
            sickle.GoldCost *= 5;
        }

        public void IncreaseSickleQuality(Sickle sickle)
        {
            sickle.UpgradeStatus++;
            sickle.HarvestIncrease++;
            sickle.Quality = sickle.QualityTypes[sickle.UpgradeStatus];
        }
    }
}
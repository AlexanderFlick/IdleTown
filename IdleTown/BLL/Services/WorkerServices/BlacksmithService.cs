using BLL.Models;
using BLL.Models.Townspeople;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services.WorkerServices
{
    public interface IBlackSmithService
    {
        void Hire(Person person, Blacksmith blacksmith, Wheat wheat, Stone stone);
        void UpgradeSickle(Person person, Blacksmith blacksmith, Stone stone, Farmer farmer);
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

        public void Hire(Person person, Blacksmith blacksmith, Wheat wheat, Stone stone)
        {
            blacksmith.Active = CanAffordBlacksmith(person, blacksmith, wheat, stone);
            if (blacksmith.Active)
            {
                PayForBlacksmith(person, blacksmith, wheat, stone);
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

        public void UpgradeSickle(Person person, Blacksmith blacksmith, Stone stone, Farmer farmer)
        {
            blacksmith.SickleActive = PayForSickle(person, blacksmith, stone);
            if (blacksmith.SickleActive)
            {
                IncreaseSickleCost(blacksmith);
                IncreaseSickleQuality(blacksmith);
                IncreaseFarmerHarvestPerSecond(blacksmith, farmer);
            }
        }

        public bool PayForSickle(Person person, Blacksmith blacksmith, Stone stone)
        {
            var active = false;
            if (person.Gold >= blacksmith.SickleGoldCost && stone.Total >= blacksmith.SickleStoneCost)
            {
                person.Gold = _is.PayFor(person.Gold, blacksmith.SickleGoldCost);
                stone.Total = _is.PayFor(stone.Total, blacksmith.SickleStoneCost);
                active = true;
            }
            return active;
        }

        public void IncreaseSickleCost(Blacksmith blacksmith)
        {
            blacksmith.SickleStoneCost *= 2;
            blacksmith.SickleGoldCost *= 5;
        }

        public void IncreaseSickleQuality(Blacksmith blacksmith)
        {
            blacksmith.SickleUpgradeStatus += 1;
            blacksmith.SickleQuality = blacksmith.Quality[blacksmith.SickleUpgradeStatus];
        }

        public void IncreaseFarmerHarvestPerSecond(Blacksmith blacksmith, Farmer farmer)
        {
            farmer.HarvestRate += blacksmith.SickleHarvestIncrease;
        }

    }
}

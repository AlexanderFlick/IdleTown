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
                isActive = _ts.Hire(person.Gold, blacksmith.WheatCost);
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

    }
}

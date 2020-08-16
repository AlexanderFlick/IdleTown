using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public interface IFarmerService
    {
        void Hire(Person person, Farmer farmer);
        void Harvest(Farmer farmer, Wheat wheat);
    }
    public class FarmerService : IFarmerService
    {
        private IItemService _is;
        private ITownsPeopleService _ts;

        public FarmerService(IItemService itemService, ITownsPeopleService townsPeopleService)
        {
            _is = itemService;
            _ts = townsPeopleService;
        }

        public void Hire(Person person, Farmer farmer)
        {
            farmer.Active = _ts.Hire(person.Gold, farmer.Cost);
            person.Gold = _ts.PayForHire(person.Gold, farmer.Cost);
        }

        public void Harvest(Farmer farmer, Wheat wheat)
        {
            if (farmer.Active)
            {
                wheat.Total = _is.Gather(wheat.Total, farmer.WheatPerSecond);
                wheat.Total = _is.CanNotEarnMoreThanMax(wheat.Total, wheat.Max);
            }
        }
    }
}

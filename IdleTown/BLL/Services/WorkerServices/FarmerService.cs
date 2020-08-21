using BLL.Models;
using BLL.Models.Resources;
using BLL.Models.Townspeople;

namespace BLL.Services
{
    public interface IFarmerService
    {
        void Hire(Person person, Farmer farmer);

        void Harvest(Farmer farmer, Wheat wheat, Sickle sickle);
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
            if (farmer.Active)
            {
                person.Gold = _ts.PayForHire(person.Gold, farmer.Cost);
            }
        }

        public void Harvest(Farmer farmer, Wheat wheat, Sickle sickle)
        {
            if (farmer.Active)
            {
                farmer.TotalHarvest = _ts.UpgradeItem(farmer.HarvestRate, sickle.HarvestIncrease);
                wheat.Total = _is.Gather(wheat.Total, farmer.TotalHarvest);
                wheat.Total = _is.CanNotEarnMoreThanMax(wheat.Total, wheat.Max);
            }
        }
    }
}
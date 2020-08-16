using BLL.Models;

namespace BLL.Services
{
    public interface IWheatService
    {
        void Gain(Wheat wheat);

        void BuyStorage(Person person, Storage storage, Wheat wheat);
    }

    public class WheatService : IWheatService
    {
        private IItemService _is;

        public WheatService(IItemService itemService)
        {
            _is = itemService;
        }

        public void Gain(Wheat wheat)
        {
            wheat.Total = _is.Gather(wheat.Total, wheat.PerClick);
            wheat.Total = _is.CanNotEarnMoreThanMax(wheat.Total, wheat.Max);
        }

        public void BuyStorage(Person person, Storage storage, Wheat wheat)
        {
            if (storage.Cost <= person.Gold)
            {
                person.Gold = _is.PayFor(person.Gold, storage.Cost);
                storage.Total = _is.Gather(storage.Total, storage.PerClick);
                wheat.Max = _is.Gather(wheat.Max, storage.IncreaseWheatMax);
            }
        }
    }
}
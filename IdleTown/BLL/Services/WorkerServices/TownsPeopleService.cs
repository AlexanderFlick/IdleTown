namespace BLL.Services
{
    public interface ITownsPeopleService
    {
        bool Hire(int gold, int hiringCost);

        int PayForHire(int gold, int hiringCost);
        int UpgradeItem(int skill, int mod);
    }

    public class TownsPeopleService : ITownsPeopleService
    {
        private IItemService _is;

        public TownsPeopleService(IItemService itemService)
        {
            _is = itemService;
        }

        public bool Hire(int gold, int hiringCost)
        {
            var isActive = false;
            if (hiringCost <= gold)
            {
                isActive = true;
            }
            return isActive;
        }

        public int PayForHire(int gold, int hiringCost)
        {
            gold = _is.PayFor(gold, hiringCost);
            return gold;
        }

        public int UpgradeItem(int skill, int mod)
        {
            skill *= mod;
            return mod;
        }
    }
}
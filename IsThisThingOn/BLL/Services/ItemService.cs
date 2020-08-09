namespace BLL.Services
{
    public interface IItemService
    {
        int Gather(int total);
        int Sell(int total);
        int GainGold(int priceOfItem, int gold, bool earn);
    }
    public class ItemService : IItemService
    {
        public int Gather(int total)
        {
            total++;
            return total;
        }

        public int Sell(int total)
        {
            total--;
            return total;
        }

        public int GainGold(int priceOfItem, int gold, bool earn)
        {
            if (earn)
            {
                gold += priceOfItem;
            }
            return gold;
        }
    }
}

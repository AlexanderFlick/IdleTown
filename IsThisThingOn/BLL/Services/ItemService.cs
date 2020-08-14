namespace BLL.Services
{
    public interface IItemService
    {
        int Gather(int total, int delta);
        int CanNotEarnMoreThanMax(int total, int max);
        int PayFor(int total, int cost);
        int IncreasePriceOnPurchase(int costOfIncrease, int price);
    }
    public class ItemService : IItemService
    {
        public int Gather(int total, int delta)
        {
            total += delta;
            return total;
        }

        public int CanNotEarnMoreThanMax(int total, int max)
        {
            if(total > max)
            {
                total = max;
            }
            return total;
        }

        public int PayFor(int total, int cost)
        {
            if(cost <= total)
            {
                total -= cost;
            }
            return total;
        }

        public int IncreasePriceOnPurchase(int costOfIncrease, int price)
        {
            price *= costOfIncrease;
            return price;
        }
    }
}

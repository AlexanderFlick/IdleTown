namespace BLL.Services
{
    public interface IItemService
    {
        int Gather(int total, int delta);
        int Pay(int total, int cost);
    }
    public class ItemService : IItemService
    {
        public int Gather(int total, int delta)
        {
            total += delta;
            return total;
        }

        public int Pay(int total, int cost)
        {
            if(cost <= total)
            {
                total -= cost;
            }
            return total;
        }
    }
}

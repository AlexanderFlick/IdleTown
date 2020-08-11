namespace BLL.Services
{
    public interface IItemService
    {
        int Gather(int total, int delta);
    }
    public class ItemService : IItemService
    {
        public int Gather(int total, int delta)
        {
            total += delta;
            return total;
        }
    }
}

using IdleTown.BLL.Models.Resources;
using IdleTown.BLL.Models.Tools;

namespace IdleTown.BLL.Services
{
    public interface IMineService
    {
        Minecart AddStoneTo(Minecart minecart);
        Chest PutMinecartContentsInChest(Minecart minecart, Chest chest);
        Minecart EmptyContentsOf(Minecart minecart);
    }

    public class MineService : IMineService
    {
        public Minecart AddStoneTo(Minecart minecart)
        {
            if (minecart.Max > minecart.Stones.Count)
                minecart.Stones.Add(new Stone());
            return minecart;
        }

        public Minecart EmptyContentsOf(Minecart minecart)
        {
            return minecart.Empty();
        }

        public Chest PutMinecartContentsInChest(Minecart minecart, Chest chest)
        {
            foreach (var stone in minecart.Stones)
                chest.Contents.Add(stone);
            return chest;
        }
    }
}
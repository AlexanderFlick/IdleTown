using BLL.Models;
using BLL.Models.Items;
using BLL.Wrapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public interface IResourceService
    {
        Minecart AddStoneTo(Minecart minecart);
        Minecart EmptyContentsOf(Minecart minecart);
        Chest PutMinecartContentsIntoChest(Minecart minecart, Chest chest);
    }
    public class ResourceService : IResourceService
    {
        private readonly IRandom random;

        public ResourceService(IRandom rand)
        {
            random = rand;
        }

        public Stone Stone()
        {
            var stone = new Stone();
            stone.Quality = GetStoneQuality();
            return stone;
        }

        public StoneQuality GetStoneQuality()
        {
            StoneQuality stoneQuality = (random.Integer() > 50) ? StoneQuality.Good : StoneQuality.Great;
            return stoneQuality;
        }

        public Minecart AddStoneTo(Minecart minecart)
        {
            if (minecart.Max > minecart.Stones.Count)
                minecart.Stones.Add(Stone());
            return minecart;
        }

        public Minecart EmptyContentsOf(Minecart minecart)
        {
            minecart.Stones.Clear();
            return minecart;
        }

        public Chest PutMinecartContentsIntoChest(Minecart minecart, Chest chest)
        {
            foreach (var stone in minecart.Stones)
                chest.Contents.Add(stone);
            return chest;
        }
    }
}

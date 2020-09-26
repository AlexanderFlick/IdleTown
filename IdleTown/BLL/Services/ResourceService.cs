using BLL.Models.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public interface IResourceService
    {

    }
    public class ResourceService : IResourceService
    {
        public Minecart AddStoneTo(Minecart minecart)
        {
            if (minecart.Max > minecart.Stones.Count)
                minecart.Stones.Add(Stone());
            return minecart;
        }

        public Stone Stone()
        {
            return new Stone { Quality = StoneQuality.Good, };
        }

        public List<Resource> ReturnMinecartContentsTo(List<Resource> resources)
        {
            var chestContents = new List<Resource>();
            foreach (var resource in resources)
                chestContents.Add(resource);
            return chestContents;
        }
    }
}

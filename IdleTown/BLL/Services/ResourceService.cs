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
            if(minecart.Max > minecart.Stones.Count)
            {
                var stone = new Stone { Quality = StoneQuality.Good, };
                minecart.Stones.Add(stone);
            }
            return minecart;
        }
    }
}

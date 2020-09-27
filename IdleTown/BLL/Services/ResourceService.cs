﻿using BLL.Models;
using BLL.Models.Items;
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
        public Stone Stone()
        {
            return new Stone { Quality = StoneQuality.Good, };
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

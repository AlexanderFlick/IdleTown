﻿using BLL.Models.Items;
using System.Collections.Generic;

namespace BLL.Models
{
    public class Player
    {
        public Minecart Minecart { get; set; } = new Minecart();
        public Chest Chest { get; set; } = new Chest();
    }
}

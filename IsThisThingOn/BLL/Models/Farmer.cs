﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class Farmer
    {
        public int Total { get; set; }
        public int Cost { get; set; } = 4;
        public int HarvestRate { get; set; } = 1000;
        public bool Active { get; set; } = false;
        public int WheatPerSecond { get; set; } = 1;
        public int TotalHarvest { get; set; }
        public int PerClick { get; set; } = 1;
        public int IncreaseWithPurchase { get; set; } = 10;
    }
}

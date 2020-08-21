using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.Townspeople
{
    public class Blacksmith : BasicWorker
    {
        public bool HammerActive { get; set; }
        public bool SickleActive { get; set; }
        public string SickleQuality { get; set; }
        public int SickleUpgradeStatus { get; set; } = 0;
        public int WheatCost { get; set; } = 6;
        public int StoneCost { get; set; } = 5;
        public int SickleStoneCost { get; set; } = 2;
        public int SickleGoldCost { get; set; } = 3;
        public int SickleHarvestIncrease { get; set; } = 1;

        public List<string> Quality = new List<string> { "Nothing", "Iron", "Steel", "Tungsten", "Diamond" };
    }
}

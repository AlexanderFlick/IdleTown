using BLL.Models.Global;
using System.Collections.Generic;

namespace BLL.Models.Resources
{
    public class Sickle : BasicItem
    {
        public bool Active { get; set; } = false;
        public string Quality { get; set; }
        public int UpgradeStatus { get; set; } = 0;
        public int StoneCost { get; set; } = 2;
        public int GoldCost { get; set; } = 3;
        public List<string> QualityTypes = new List<string> { "Nothing", "Iron", "Steel", "Tungsten", "Diamond" };
    }
}
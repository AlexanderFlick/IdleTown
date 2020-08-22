using BLL.Models.Global;
using System.Collections.Generic;

namespace BLL.Models.Resources
{
    public class Sickle : BasicItem
    {
        public string Quality { get; set; }
        
        public new int StoneCost { get; set; } = 2;
        public new int GoldCost { get; set; } = 3;
        public List<string> QualityTypes = new List<string> { "Nothing", "Iron", "Steel", "Tungsten", "Diamond" };
    }
}
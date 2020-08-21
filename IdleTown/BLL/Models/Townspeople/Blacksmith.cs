using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.Townspeople
{
    public class Blacksmith : BasicWorker
    {
        public int HammerActive { get; set; }
        public int SickleActive { get; set; }
        public List<string> Quality { get; set; } = new List<string> { "Iron", "Steel" };
        public List<string> HammerQuality { get; set; }
        public List<string> SickQuality { get; set; }
        public int WheatCost { get; set; } = 6;
        public int StoneCost { get; set; } = 5;
    }
}

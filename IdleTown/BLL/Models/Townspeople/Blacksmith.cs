using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.Townspeople
{
    public class Blacksmith : BasicWorker
    {
        public int HammerTotal { get; set; }
        public int SickleTotal { get; set; }
        public List<string> HammerQuality { get; set; }
        public List<string> SickQuality { get; set; }
        public int WheatCost { get; set; } = 6;
        public int StoneCost { get; set; } = 5;
    }
}

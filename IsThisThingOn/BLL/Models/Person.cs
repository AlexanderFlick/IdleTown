using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class Person
    {
        public int Gold { get; set; }
        public int WheatTotal { get; set; }
        public int WheatMax { get; set; } = 10;
        public int WheatPrice { get; set; } = 2;
        public bool EarnWheat { get; set; } = false;
        public int Farmers { get; set; }
        public int WheatPerSec { get; set; } = 1;
        public int WheatPerClick { get; set; } = 1;
        public int FarmerGoldCost { get; set; } = 4;
        public bool FarmerActive { get; set; } = false;
        public int StorageUnits { get; set; } 
    }
}

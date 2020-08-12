using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class Warehouse
    {
        public int Total { get; set; }
        public int Cost { get; set; } = 4;
        public int IncreaseStoneMax { get; set; } = 25;
        public int PerClick { get; set; } = 1;
    }
}

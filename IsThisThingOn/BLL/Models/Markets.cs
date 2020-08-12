using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class Markets
    {
        public int Total { get; set; }
        public int Cost { get; set; } = 4;
        public int Multiplier { get; set; } = 2;
        public int PerClick { get; set; } = 1;
    }
}

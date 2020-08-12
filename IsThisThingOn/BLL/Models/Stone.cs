using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class Stone
    {
        public int Total { get; set; }
        public int Max { get; set; } = 5;
        public int Price { get; set; } = 7;
        public int PerClick { get; set; } = 1;
        public bool Earn { get; set; } = false;
        public int Sold { get; set; } = 1;
    }
}

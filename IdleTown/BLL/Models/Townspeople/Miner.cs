using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class Miner : BasicWorker
    {
        public int StonePerSecond { get; set; } = 1;
        public int WheatCost { get; set; } = 10;
        public new int Cost { get; set; } = 100;
    }
}

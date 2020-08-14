using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class Miner : BasicWorker
    {
        public int HarvestRate { get; set; } = 2000;
        public int StonePerSecond { get; set; } = 1;
    }
}

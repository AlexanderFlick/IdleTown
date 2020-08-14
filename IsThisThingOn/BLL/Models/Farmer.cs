using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class Farmer : BasicWorker
    {
        public int HarvestRate { get; set; } = 1000;
        public int WheatPerSecond { get; set; } = 1;
    }
}

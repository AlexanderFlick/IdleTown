using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.Market
{
    public class Merchant : BasicWorker
    {
        public int WheatMultiplier { get; set; }
        public int StoneMultiplier { get; set; }
        public int WheatPrice { get; set; }
        public int StonePrice { get; set; }
    }
}

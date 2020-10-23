using IdleTown.BLL.Models.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdleTown.BLL.Models.Tools
{
    public class Minecart
    {
        public int Max { get; set; }
        public List<Stone> Stones { get; set; } = new List<Stone>();
    }
}

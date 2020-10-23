using IdleTown.BLL.Models.Resources;
using System.Collections.Generic;

namespace IdleTown.BLL.Models.Tools
{
    public class Minecart
    {
        public int Max { get; set; } = 10;
        public List<Stone> Stones { get; set; } = new List<Stone>();
    }
}
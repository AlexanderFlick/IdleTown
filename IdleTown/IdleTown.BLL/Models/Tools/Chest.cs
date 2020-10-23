using System.Collections.Generic;
using IdleTown.BLL.Models.Resources;

namespace IdleTown.BLL.Models.Tools
{
    public class Chest
    {
        public List<Resource> Contents { get; set; } = new List<Resource>();
    }
}

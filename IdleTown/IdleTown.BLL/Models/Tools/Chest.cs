using IdleTown.BLL.Models.Resources;
using System.Collections.Generic;

namespace IdleTown.BLL.Models.Tools
{
    public class Chest
    {
        public List<Resource> Contents { get; set; } = new List<Resource>();
    }
}
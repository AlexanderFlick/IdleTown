using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.Items
{
    public class Chest
    {
        public List<Resource> Contents { get; set; } = new List<Resource>();
    }
}

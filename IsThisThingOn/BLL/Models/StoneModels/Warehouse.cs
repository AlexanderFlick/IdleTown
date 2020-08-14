using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class Warehouse : BasicStorage
    {
        public int IncreaseStoneMax { get; set; } = 25;
    }
}

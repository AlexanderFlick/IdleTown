using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.Items
{
    public class Minecart
    {
        public List<Stone> Stones { get; set; } = new List<Stone>();
        public int Max { get; set; } = 10;
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class Person
    {
        public int gold { get; set; }
        public int wheatTotal { get; set; }
        public int wheatMax { get; set; } = 10;
        public int wheatPrice { get; set; } = 2;
        public bool EarnWheat { get; set; } = false;
    }
}

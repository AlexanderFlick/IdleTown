﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class Wheat
    {
        public int Total { get; set; }
        public int Max { get; set; } = 10;
        public int Price { get; set; } = 2;
        public int PerClick { get; set; } = 1;
        public bool Earn { get; set; } = false;
    }
}
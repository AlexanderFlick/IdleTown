﻿using BLL.Models.Items;
using System.Collections.Generic;

namespace BLL.Models
{
    public class Player
    {
        public int StoneMax { get; set; }
        public List<Stone> Stones { get; set; }
    }
}

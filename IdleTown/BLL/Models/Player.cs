using BLL.Models.Items;
using System.Collections.Generic;

namespace BLL.Models
{
    public class Player
    {
        public int StoneMax { get; set; }
        public Minecart Minecart { get; set; } = new Minecart();
    }
}

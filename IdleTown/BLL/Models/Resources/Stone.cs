using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.Items
{
    public enum StoneQuality
    {
        Good, Great
    }

    public class Stone : Resource
    {
        public StoneQuality Quality { get; set; }

        public Stone(int qualityIndex)
        {
            Quality = GetStoneQuality(qualityIndex);
        }

        public StoneQuality GetStoneQuality(int qualityIndex)
        {
            StoneQuality stoneQuality = (qualityIndex > 50) ? StoneQuality.Good : StoneQuality.Great;
            return stoneQuality;
        }
    }
}

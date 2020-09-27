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
    }
}

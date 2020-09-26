using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.Items
{
    public enum Quality
    {
        Rock, Iron,
    }

    public class Stone : Resource
    {
        public string Quality { get; set; }
        Quality Type { get; set; }
    }
}

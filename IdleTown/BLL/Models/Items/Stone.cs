using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.Items
{
    public class Stone : Resource
    {
        public string Quality { get; set; }
        List<string> QualityTypes { get; set; } = new List<string> { "Rock", "Iron" };
    }
}

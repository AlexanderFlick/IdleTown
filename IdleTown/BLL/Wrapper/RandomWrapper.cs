using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Wrapper
{
    public interface IRandom
    {
        int Integer();
    }
    public class RandomWrapper : IRandom
    {
        Random random = new Random();
        public int Integer()
        {
            var randomInt = random.Next(1, 100);
            return randomInt;
        }
    }
}

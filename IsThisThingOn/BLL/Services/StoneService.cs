using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public interface IStoneService
    {
        void Gain(Stone stone);
    }


    public class StoneService : IStoneService
    {
        private IItemService _is;

        public StoneService(IItemService itemService)
        {
            _is = itemService;
        }

        public void Gain(Stone stone)
        {
            if (stone.Total >= stone.Max)
            {
                stone.Total = stone.Max;
            }
            else
            {
                stone.Total = _is.Gather(stone.Total, stone.PerClick);
            }
        }
    }
}

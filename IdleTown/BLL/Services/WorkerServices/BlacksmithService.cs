using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services.WorkerServices
{
    public interface IBlackSmithService
    {
        void Hire();
    }
    public class BlacksmithService : IBlackSmithService
    {
        private ITownsPeopleService _ts;
        private IItemService _is;

        public BlacksmithService(IItemService itemService, ITownsPeopleService townsPeopleService)
        {
            _is = itemService;
            _ts = townsPeopleService;
        }

        public void Hire()
        {
            //stone, wheat and gold
        }

    }
}

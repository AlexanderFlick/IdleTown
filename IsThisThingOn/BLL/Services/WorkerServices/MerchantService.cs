using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services.WorkerServices
{
    public interface IMerchantService
    {

    }
    public class MerchantService : IMerchantService
    {
        private ITownsPeopleService _ts;

        public MerchantService(ITownsPeopleService townsPeopleService)
        {
            _ts = townsPeopleService;
        }
    }
}

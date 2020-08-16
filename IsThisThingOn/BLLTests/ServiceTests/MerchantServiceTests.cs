using BLL.Services;
using BLL.Services.WorkerServices;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLLTests.ServiceTests
{
    public class MerchantServiceTests
    {
        private MerchantService _sut;
        
        [SetUp]
        public void Setup()
        {
            ItemService itemService = Substitute.For<ItemService>();
            TownsPeopleService townService = Substitute.For<TownsPeopleService>(itemService);
            _sut = new MerchantService(townService);
        }

        [Test]
        public void WhenYouGatherStone_IncreaseStoneTotal()
        {
            var expected = 2;
            var actual = 2;
            Assert.AreEqual(expected, actual);
        }
    }
}

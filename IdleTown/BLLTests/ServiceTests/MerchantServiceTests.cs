using BLL.Models;
using BLL.Models.Market;
using BLL.Services;
using BLL.Services.WorkerServices;
using NSubstitute;
using NUnit.Framework;

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
            _sut = new MerchantService(itemService, townService);
        }

        [Test]
        public void IfYouHireMerchant_YouLoseWheatToPayForThem()
        {
            var merchant = GenerateTestMerchant();
            var wheat = GenerateTestWheat();
            merchant.Cost = 2;
            wheat.Total = 4;

            _sut.Hire(merchant, wheat);
            var expected = 2;
            var actual = wheat.Total;
            Assert.AreEqual(expected, actual);
        }

        private Merchant GenerateTestMerchant()
        {
            return new Merchant
            {
                Cost = 10,
                Active = false,
                WheatPrice = 2,
                StonePrice = 7,
            };
        }

        private Wheat GenerateTestWheat()
        {
            return new Wheat
            {
                Total = 5,
                Max = 10,
                PerClick = 1,
            };
        }
    }
}
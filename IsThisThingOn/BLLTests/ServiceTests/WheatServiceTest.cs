using BLL.Models;
using BLL.Services;
using NSubstitute;
using NUnit.Framework;

namespace BLLTests.ServiceTests
{
    public class WheatServiceTest
    {
        private WheatService _sut;

        [SetUp]
        public void Setup()
        {
            ItemService itemService = Substitute.For<ItemService>();
            _sut = new WheatService(itemService);
        }

        [Test]
        public void WhenYouGatherWheat_TotalIncreases()
        {
            var wheat = GenerateTestWheat();

            _sut.Gain(wheat);
            var expected = 6;
            var actual = wheat.Total;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CantGainMoreWheatThanMax()
        {
            var wheat = GenerateTestWheat();

            wheat.Total = 10;
            _sut.Gain(wheat);
            var expected = 10;
            var actual = wheat.Total;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void WhenYouSellWheat_TotalDecreases()
        {
            var person = GenerateTestPerson();
            var wheat = GenerateTestWheat();

            _sut.Sell(person, wheat);
            var expected = 4;
            var actual = wheat.Total;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CantSellWheatIfTotalIsZero()
        {
            var person = GenerateTestPerson();
            var wheat = GenerateTestWheat();

            wheat.Total = 0;
            _sut.Sell(person, wheat);
            var expected = 0;
            var actual = wheat.Total;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DontEarnGoldIfWheatTotalIsZero()
        {
            var person = GenerateTestPerson();
            var wheat = GenerateTestWheat();

            wheat.Total = 0;
            _sut.Sell(person, wheat);
            var expected = 2;
            var actual = person.Gold;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HireFarmerIfEnoughGold()
        {
            var person = GenerateTestPerson();
            var wheat = GenerateTestWheat();
            var farmer = GenerateTestFarmer();

            _sut.HireFarmer(person, farmer, wheat);
            var expected = 1;
            var actual = farmer.Total;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IfYouHireAFarmer_YouActivateHarvesting()
        {
            var person = GenerateTestPerson();
            var wheat = GenerateTestWheat();
            var farmer = GenerateTestFarmer();

            _sut.HireFarmer(person, farmer, wheat);
            var expected = true;
            var actual = farmer.Active;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IfYouHireAFarmer_YouLoseGold()
        {
            var person = GenerateTestPerson();
            var wheat = GenerateTestWheat();
            var farmer = GenerateTestFarmer();

            _sut.HireFarmer(person, farmer, wheat);
            var expected = 1;
            var actual = person.Gold;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IfYouHireAFarmer_YouCantEarnMoreThanMaxWheat()
        {
            var person = GenerateTestPerson();
            var wheat = GenerateTestWheat();
            var farmer = GenerateTestFarmer();

            _sut.HireFarmer(person, farmer, wheat);
            var expected = 10;
            var actual = wheat.Max;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void BuyStorageIfEnoughGold()
        {
            var person = GenerateTestPerson();
            var storage = GenerateTestStorage();
            var wheat = GenerateTestWheat();

            _sut.BuyStorage(person, storage, wheat);
            var expected = 1;
            var actual = storage.Total;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CantBuyStorageIfShortGold()
        {
            var person = GenerateTestPerson();
            var storage = GenerateTestStorage();
            var wheat = GenerateTestWheat();

            storage.Cost = 10;
            _sut.BuyStorage(person, storage, wheat);
            var expected = 0;
            var actual = storage.Total;
            Assert.AreEqual(expected, actual);
        }

        private Person GenerateTestPerson()
        {
            return new Person
            {
                Gold = 2,
            };
        }

        private Wheat GenerateTestWheat()
        {
            return new Wheat
            {
                Total = 5,
                Max = 10,
                Price = 2,
                Earn = false,
                PerClick = 1,
            };
        }

        private Farmer GenerateTestFarmer()
        {
            return new Farmer
            {
                Total = 0,
                Cost = 1,
            };
        }

        private Storage GenerateTestStorage()
        {
            return new Storage
            {
                Total = 0,
                Cost = 2,
                IncreaseWheatMax = 2,
            };
        }
    }
}
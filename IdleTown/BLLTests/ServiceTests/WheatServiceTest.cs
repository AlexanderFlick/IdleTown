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
                Earn = false,
                PerClick = 1,
            };
        }

        private Farmer GenerateTestFarmer()
        {
            return new Farmer
            {
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
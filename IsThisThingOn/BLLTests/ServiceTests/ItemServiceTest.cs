using BLL.Models;
using BLL.Services;
using NSubstitute;
using NUnit.Framework;

namespace BLLTests
{
    public class ItemServiceTest
    {
        private ItemService _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new ItemService();
        }

        [Test]
        public void WhenYouGatherAnItem_TotalIncreases()
        {
            var startingAmount = 0;
            var inc = 1;
            var expected = 1;
            var actual = _sut.Gather(startingAmount, inc);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void WhenYouGainGold_YouEarnBasedOnItemPrice()
        {
            var person = GenerateTestPerson();
            var wheat = GenerateTestWheat();
            wheat.Earn = true;
            var expected = 4;
            var actual = _sut.Gather(person.Gold, wheat.Price);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void WhenYouBuyAnUpgrade_YouLoseGold()
        {
            var person = GenerateTestPerson();
            var farmer = GenerateTestFarmer();

            var expected = 1;
            var actual = _sut.Pay(person.Gold, farmer.Cost);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CanNotBuyAnUpgrade_IfNotEnoughGold()
        {
            var person = GenerateTestPerson();
            var farmer = GenerateTestFarmer();
            farmer.Cost = 100;

            var expected = 2;
            var actual = _sut.Pay(person.Gold, farmer.Cost);
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
                Earn = false
            };
        }

        private Farmer GenerateTestFarmer()
        {
            return new Farmer
            {
                Total = 0,
                Cost = 1,
                HarvestRate = 1,
                WheatPerSecond = 1,
                Active = true,
            };
        }
    }
}
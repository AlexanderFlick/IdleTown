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
        public void WhenYouSellAnItem_TotalDecreases()
        {
            var startingAmount = 10;
            var expected = 9;
            var actual = _sut.Sell(startingAmount);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void WhenYouGainGold_YouEarnBasedOnItemPrice()
        {
            var person = GenerateTestPerson();
            var wheat = GenerateTestWheat();
            wheat.Earn = true;
            var expected = 4;
            var actual = _sut.GainGold(wheat.Price, person.Gold, wheat.Earn);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void YouDoNotEarnGoldIfYouHaveZeroOfAnItem()
        {
            var person = GenerateTestPerson();
            var wheat = GenerateTestWheat();
            wheat.Earn = false;
            wheat.Total = 0;
            var expected = 2;
            var actual = _sut.GainGold(wheat.Price, person.Gold, wheat.Earn);
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
    }
}
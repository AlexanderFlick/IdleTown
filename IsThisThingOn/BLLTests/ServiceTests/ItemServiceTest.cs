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
            person.EarnWheat = true;
            var expected = 4;
            var actual = _sut.GainGold(person.WheatPrice, person.Gold, person.EarnWheat);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void YouDoNotEarnGoldIfYouHaveZeroOfAnItem()
        {
            var person = GenerateTestPerson();
            person.EarnWheat = false;
            person.WheatTotal = 0;
            var expected = 2;
            var actual = _sut.GainGold(person.WheatPrice, person.Gold, person.EarnWheat);
            Assert.AreEqual(expected, actual);
        }

        private Person GenerateTestPerson()
        {
            return new Person
            {
                Gold = 2,
                WheatTotal = 5,
                WheatMax = 10,
                WheatPrice = 2,
                EarnWheat = false,
            };
        }
    }
}
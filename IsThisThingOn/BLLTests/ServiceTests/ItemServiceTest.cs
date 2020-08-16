using BLL.Models;
using BLL.Models.Market;
using BLL.Services;
using NSubstitute;
using NUnit.Framework;
using System;

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
        public void WhenYouGatherAnItem_CanNotGainMoreThanMax()
        {
            var total = 10;
            var max = 5;
            var expected = 5;
            var actual = _sut.CanNotEarnMoreThanMax(total, max);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void WhenYouBuyAnUpgrade_YouLoseGold()
        {
            var person = GenerateTestPerson();
            var farmer = GenerateTestFarmer();

            var expected = 1;
            var actual = _sut.PayFor(person.Gold, farmer.Cost);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CanNotBuyAnUpgrade_IfNotEnoughGold()
        {
            var person = GenerateTestPerson();
            var farmer = GenerateTestFarmer();
            farmer.Cost = 100;

            var expected = 2;
            var actual = _sut.PayFor(person.Gold, farmer.Cost);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IncreasePriceOfItem()
        {
            var person = GenerateTestPerson();
            var farmer = GenerateTestFarmer();
            farmer.Cost = 4;
            farmer.IncreaseWithPurchase = 2;

            var expected = 8;
            var actual = _sut.IncreasePriceOnPurchase(farmer.IncreaseWithPurchase, farmer.Cost);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IfYouSellAnItem_YouLoseHoweverManyYouSold()
        {
            var merchant = GenerateTestMerchant();
            var wheat = GenerateTestWheat();
            merchant.WheatQuantitySold = 2;
            _sut.Sell(wheat.Total, merchant.WheatQuantitySold);

            var expected = 3;
            var actual = wheat.Total;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void YouCanNotSellMoreThanYouHave()
        {
            var merchant = GenerateTestMerchant();
            var wheat = GenerateTestWheat();
            merchant.WheatQuantitySold = 188;
            _sut.Sell(wheat.Total, merchant.WheatQuantitySold);

            var expected = 5;
            var actual = wheat.Total;
            Assert.AreEqual(expected, actual);
        }

        private Merchant GenerateTestMerchant()
        {
            return new Merchant
            {
                StoneQuantitySold = 2,
                StonePrice = 7,
            };
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
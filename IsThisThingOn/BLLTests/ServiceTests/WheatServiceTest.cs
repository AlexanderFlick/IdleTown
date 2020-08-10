using BLL.Models;
using BLL.Services;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

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
            var person = GenerateTestPerson();
            _sut.Gain(person);
            var expected = 6;
            var actual = person.WheatTotal;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CantGainMoreWheatThanMax()
        {
            var person = GenerateTestPerson();
            person.WheatTotal = 10;
            _sut.Gain(person);
            var expected = 10;
            var actual = person.WheatTotal;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void WhenYouSellWheat_TotalDecreases()
        {
            var person = GenerateTestPerson();
            _sut.Sell(person);
            var expected = 4;
            var actual = person.WheatTotal;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CantSellWheatIfTotalIsZero()
        {
            var person = GenerateTestPerson();
            person.WheatTotal = 0;
            _sut.Sell(person);
            var expected = 0;
            var actual = person.WheatTotal;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HireFarmerIfEnoughGold()
        {
            var person = GenerateTestPerson();
            _sut.HireFarmer(person);
            var expected = 1;
            var actual = person.Farmers;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void BuyStorageIfEnoughGold()
        {
            var person = GenerateTestPerson();
            _sut.BuyStorage(person);
            var expected = 1;
            var actual = person.StorageUnits;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CantBuyStorageIfShortGold()
        {
            var person = GenerateTestPerson();
            person.StorageCost = 10;
            _sut.BuyStorage(person);
            var expected = 0;
            var actual = person.StorageUnits;
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
                Farmers = 0,
                FarmerGoldCost = 1,
                StorageCost = 1,
            };
        }
    }
}

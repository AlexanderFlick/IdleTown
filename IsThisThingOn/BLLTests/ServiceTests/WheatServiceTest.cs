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
            var actual = person.wheatTotal;
            Assert.AreEqual(expected, actual);
        }

        private Person GenerateTestPerson()
        {
            return new Person
            {
                gold = 2,
                wheatTotal = 5,
                wheatMax = 10,
                wheatPrice = 2,
                EarnWheat = false,
            };
        }
    }
}

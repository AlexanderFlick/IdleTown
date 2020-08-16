using BLL.Models;
using BLL.Services;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLLTests.ServiceTests
{
    public class TownsPeopleServiceTests
    {
        private TownsPeopleService _sut;

        [SetUp]
        public void Setup()
        {
            ItemService itemService = Substitute.For<ItemService>();
            _sut = new TownsPeopleService(itemService);
        }

        [Test]
        public void IfYouHaveEnoughGold_YouCanBuyTownsPerson()
        {
            var farmer = GenerateTestFarmer();
            var gold = 12;

            var expected = true;
            var actual = _sut.Hire(gold, farmer.Cost);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IfYouDoNotHaveEnoughGold_YouCanNotBuyTownsPerson()
        {
            var farmer = GenerateTestFarmer();
            var gold = 6;
            _sut.Hire(gold, farmer.Cost);


            var expected = false;
            var actual = farmer.Active;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IfYouHireSomeone_YouLoseGold()
        {
            var person = GenerateTestPerson();
            var farmer = GenerateTestFarmer();
            person.Gold = 12;

            var expected = 2;
            var actual = _sut.PayForHire(person.Gold, farmer.Cost);
            Assert.AreEqual(expected, actual);
        }

        private Farmer GenerateTestFarmer()
        {
            return new Farmer
            {
                Active = false,
                Cost = 10,
                PerClick = 2,
                HarvestRate = 2,
            };
        }
        private Person GenerateTestPerson()
        {
            return new Person
            {
                Gold = 10,
            };
        }
    }
}

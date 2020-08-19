using BLL.Models;
using BLL.Models.Townspeople;
using BLL.Services;
using BLL.Services.WorkerServices;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLLTests.ServiceTests
{
    public class BlacksmithServiceTests
    {
        private BlacksmithService _sut;

        [SetUp]
        public void Setup()
        {
            ItemService itemService = Substitute.For<ItemService>();
            TownsPeopleService townsPeopleService = Substitute.For<TownsPeopleService>(itemService);
            _sut = new BlacksmithService(itemService, townsPeopleService);
        }

        [Test]
        public void IfYouCanPayForBlacksmith_BlacksmithBecomesActive()
        {
            var person = GenerateTestPerson();
            var blacksmith = GenerateTestBlacksmith();
            var wheat = GenerateTestWheat();
            var stone = GenerateTestStone();

            _sut.Hire(person, blacksmith, wheat, stone);
            var expected = true;
            var actual = blacksmith.Active;
            Assert.AreEqual(expected, actual);
        }

        private Blacksmith GenerateTestBlacksmith()
        {
            return new Blacksmith
            {
                Active = false,
                Cost = 10,
                WheatCost = 4,
                StoneCost = 4,
            };
        }

        private Person GenerateTestPerson()
        {
            return new Person
            {
                Gold = 12,
            };
        }

        private Wheat GenerateTestWheat()
        {
            return new Wheat
            {
                Total = 50,
                Max = 100,
                PerClick = 1,
            };
        }
        private Stone GenerateTestStone()
        {
            return new Stone
            {
                Total = 50,
                Max = 100,
                PerClick = 1,
            };
        }
    }
}

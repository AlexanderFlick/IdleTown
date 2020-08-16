using BLL.Models;
using BLL.Services;
using NSubstitute;
using NUnit.Framework;

namespace BLLTests.ServiceTests
{
    public class FarmerServiceTests
    {
        private FarmerService _sut;

        [SetUp]
        public void Setup()
        {
            ItemService itemService = Substitute.For<ItemService>();
            TownsPeopleService townsPeopleService = Substitute.For<TownsPeopleService>(itemService);
            _sut = new FarmerService(itemService, townsPeopleService);
        }

        [Test]
        public void IfYouHireAFarmer_YouActivateHarvesting()
        {
            var person = GenerateTestPerson();
            var farmer = GenerateTestFarmer();
            farmer.Cost = 1;

            _sut.Hire(person, farmer);
            var expected = true;
            var actual = farmer.Active;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IfYouHireAFarmer_YouLoseGold()
        {
            var person = GenerateTestPerson();
            var farmer = GenerateTestFarmer();
            person.Gold = 10;
            farmer.Cost = 5;

            _sut.Hire(person, farmer);
            var expected = 5;
            var actual = person.Gold;
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
                Gold = 2,
            };
        }
    }
}
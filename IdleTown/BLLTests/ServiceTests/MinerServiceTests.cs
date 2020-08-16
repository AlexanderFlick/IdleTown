using BLL.Models;
using BLL.Services;
using BLL.Services.WorkerServices;
using NSubstitute;
using NUnit.Framework;

namespace BLLTests.ServiceTests
{
    public class MinerServiceTests
    {
        private MinerService _sut;

        [SetUp]
        public void Setup()
        {
            ItemService itemService = Substitute.For<ItemService>();
            TownsPeopleService townsPeopleService = Substitute.For<TownsPeopleService>(itemService);
            _sut = new MinerService(itemService, townsPeopleService);
        }

        [Test]
        public void IfYouHireAFarmer_YouActivateHarvesting()
        {
            var person = GenerateTestPerson();
            var miner = GenerateTestMiner();
            miner.Cost = 1;

            _sut.Hire(person, miner);
            var expected = true;
            var actual = miner.Active;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IfYouHireAFarmer_YouLoseGold()
        {
            var person = GenerateTestPerson();
            var miner = GenerateTestMiner();
            person.Gold = 10;
            miner.Cost = 5;

            _sut.Hire(person, miner);
            var expected = 5;
            var actual = person.Gold;
            Assert.AreEqual(expected, actual);
        }

        private Miner GenerateTestMiner()
        {
            return new Miner
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
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
        public void IfYouHireAMiner_YouActivateHarvesting()
        {
            var person = GenerateTestPerson();
            var miner = GenerateTestMiner();
            var wheat = GenerateTestWheat();
            miner.Cost = 1;

            _sut.Hire(person, miner, wheat);
            var expected = true;
            var actual = miner.Active;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IfYouHireAMiner_YouLoseGold()
        {
            var person = GenerateTestPerson();
            var miner = GenerateTestMiner();
            var wheat = GenerateTestWheat();
            person.Gold = 10;
            miner.Cost = 5;

            _sut.Hire(person, miner, wheat);
            var expected = 5;
            var actual = person.Gold;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IfYouHireAMiner_YouLoseWheat()
        {
            var person = GenerateTestPerson();
            var miner = GenerateTestMiner();
            var wheat = GenerateTestWheat();
            person.Gold = 11;

            _sut.Hire(person, miner, wheat);
            var expected = 45;
            var actual = wheat.Total;
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
                WheatCost = 5,
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
                Total = 50,
                Max = 100,
                PerClick = 1,
            };
        }
    }
}
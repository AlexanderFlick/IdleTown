using BLL.Models;
using BLL.Models.Resources;
using BLL.Services;
using NSubstitute;
using NUnit.Framework;

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

        [Test]
        public void HarvestAbilityIsIncreasedWhenItemIsUpgraded()
        {
            var miner = GenerateTestMiner();
            var pickaxe = GenerateTestPickaxe();
            var expected = 2;
            var actual = _sut.UpgradeItem(miner.HarvestRate, pickaxe.HarvestIncrease);
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

        private Miner GenerateTestMiner()
        {
            return new Miner
            {
                HarvestRate = 1,
            };
        }

        private Person GenerateTestPerson()
        {
            return new Person
            {
                Gold = 10,
            };
        }

        private Pickaxe GenerateTestPickaxe()
        {
            return new Pickaxe
            {
                HarvestIncrease = 2,
            };
        }
    }
}
using BLL.Models;
using BLL.Models.Items;
using BLL.Services;
using BLL.Wrapper;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLLTests.ServiceTests
{
    public class ResourceServiceTests
    {
        private ResourceService _sut;

        [SetUp]
        public void Setup()
        {
            RandomWrapper random = Substitute.For<RandomWrapper>();
            _sut = new ResourceService(random);
        }

        [Test]
        public void WhenYouGetStone_StoneTotalIncreases()
        {
            var player = new Player();
            player.Minecart = _sut.AddStoneTo(player.Minecart);

            var expected = 1;
            var actual = player.Minecart.Stones.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CanNotEarnMoreStoneThanMinecartMax()
        {
            var player = new Player();
            player.Minecart.Max = 1;
            player.Minecart = _sut.AddStoneTo(player.Minecart);
            player.Minecart = _sut.AddStoneTo(player.Minecart);

            var expected = 1;
            var actual = player.Minecart.Stones.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MinecartEmptiesContents()
        {
            var player = new Player();
            player.Minecart = _sut.AddStoneTo(player.Minecart);
            player.Minecart = _sut.EmptyContentsOf(player.Minecart);

            var expected = 0;
            var actual = player.Minecart.Stones.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MinecartContentsGetAddedToChest()
        {
            var player = GenerateTestPlayer();
            player.Chest = _sut.PutMinecartContentsIntoChest(player.Minecart, player.Chest);
            var expectedChestStoneCount = 2;
            var actualChestStoneCount = player.Minecart.Stones.Count;

            Assert.AreEqual(expectedChestStoneCount, actualChestStoneCount);
        }

        [Test]
        public void GivenDifferentValues_GetStoneQuality()
        {

        }

        private Player GenerateTestPlayer()
        {
            return new Player
            {
                Chest = new Chest(),
                Minecart = new Minecart { 
                    Stones = { new Stone(200), new Stone(200), } },
            };
        }
    }
}

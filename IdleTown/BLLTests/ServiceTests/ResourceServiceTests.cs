using BLL.Models;
using BLL.Models.Items;
using BLL.Services;
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
            _sut = new ResourceService();
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
    }
}

using FluentAssertions;
using IdleTown.BLL.Models.Resources;
using IdleTown.BLL.Models.Tools;
using IdleTown.BLL.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdleTown.BLL.Tests.Services
{
    public class MineServiceTests
    {
        private MineService _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new MineService();
        }

        [Test]
        public void AddingStoneToCartAddsNewStone()
        {
            var minecart = new Minecart();
            var expectedMinecart = new Minecart 
            {
                Max = 10,
                Stones = new List<Stone> { new Stone() }
            };
            var actual = _sut.AddStoneTo(minecart);
            actual.Should().BeEquivalentTo(expectedMinecart);
        }

        [Test]
        public void CanNotGainMoreStoneThanMinecartMax()
        {
            var minecart = MinecartWithThreeMax();
            var expectedMinecart = MinecartWithThreeMax();

            var actual = _sut.AddStoneTo(minecart);
            actual.Stones.Count.Should().Be(3);
            actual.Should().BeEquivalentTo(expectedMinecart);
        }

        private Minecart MinecartWithThreeMax()
        {
            return new Minecart
            {
                Max = 3,
                Stones = new List<Stone>
                {
                    new Stone(),
                    new Stone(),
                    new Stone(),
                }
            };
        }
    }
}

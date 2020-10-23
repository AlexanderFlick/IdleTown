using FluentAssertions;
using IdleTown.BLL.Models.Resources;
using IdleTown.BLL.Models.Tools;
using NUnit.Framework;
using System.Collections.Generic;

namespace IdleTown.BLL.Tests.Models
{
    public class MinecartTests
    {
        private Minecart _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new Minecart();
        }

        [Test]
        public void EmptyingTheMinecartReturnsNewMinecartWithSameMax()
        {
            var expectedMinecart = new Minecart();
            _sut.Stones.Add(new Stone());
            _sut = _sut.Empty();
            _sut.Should().BeEquivalentTo(expectedMinecart);
        }

        [Test]
        public void IncreasingMinecartMax()
        {
            var expectedMinecart = new Minecart { Max = 15 };
            var actual = _sut.IncreaseMax(5);
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
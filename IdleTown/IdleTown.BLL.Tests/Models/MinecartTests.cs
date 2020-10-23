using FluentAssertions;
using IdleTown.BLL.Models.Resources;
using IdleTown.BLL.Models.Tools;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

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
        public void EmptyingTheMinecartReturnsNewMinecart()
        {
            var expectedMinecart = new Minecart();
            _sut.Stones.Add(new Stone());
            _sut = _sut.Empty();
            _sut.Should().BeEquivalentTo(expectedMinecart);
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

using FluentAssertions;
using IdleTown.BLL.Models.Resources;
using NUnit.Framework;

namespace IdleTown.BLL.Tests.Models
{
    public class StoneTests
    {
        private Stone _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new Stone();
        }

        [Test]
        public void StoneCreatedWithDefaultQuality()
        {
            var expectedStone = new Stone { Quality = Qualities.Good };
            _sut.Should().BeEquivalentTo(expectedStone);
        }

        [Test]
        public void ImprovingStoneQualityReturnsExpectedQuality()
        {
            var expectedStone = new Stone { Quality = Qualities.Great };
            _sut.Quality = _sut.ImproveQuality();
            _sut.Should().BeEquivalentTo(expectedStone);
        }
    }
}
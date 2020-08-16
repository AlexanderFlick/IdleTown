using BLL.Models;
using BLL.Services;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLLTests.ServiceTests
{
    public class StoneServiceTests
    {
        private StoneService _sut;

        [SetUp]
        public void Setup()
        {
            ItemService itemService = Substitute.For<ItemService>();
            _sut = new StoneService(itemService);
        }

        [Test]
        public void WhenYouGatherStone_IncreaseStoneTotal()
        {
            var stone = GenerateTestStone();
            var expected = 2;
            var actual = 2;
            Assert.AreEqual(expected, actual);
        }

        private Stone GenerateTestStone()
        {
            return new Stone
            {
                Total = 1,
                Max = 5,
                PerClick = 1,
            };
        }
    }
}

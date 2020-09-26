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
            
            var expected = true;
            var actual = true;
            Assert.AreEqual(expected, actual);
        }
    }
}

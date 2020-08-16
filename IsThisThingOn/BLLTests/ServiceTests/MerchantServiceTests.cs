using BLL.Models;
using BLL.Models.Market;
using BLL.Services;
using BLL.Services.WorkerServices;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLLTests.ServiceTests
{
    public class MerchantServiceTests
    {
        private MerchantService _sut;
        
        [SetUp]
        public void Setup()
        {
            ItemService itemService = Substitute.For<ItemService>();
            TownsPeopleService townService = Substitute.For<TownsPeopleService>(itemService);
            _sut = new MerchantService(itemService, townService);
        }

        [Test]
        public void IfYouHaveEnoughGold_YouCanHireMerchant()
        {
            var merchant = GenerateTestMerchant();
            var person = GenerateTestPerson();
            person.Gold = 12;
            _sut.Hire(person, merchant);
            var expected = true;
            var actual = merchant.Active;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IfYouHireMerchant_YouLoseGoldToPayForThem()
        {
            var merchant = GenerateTestMerchant();
            var person = GenerateTestPerson();
            person.Gold = 12;
            _sut.Hire(person, merchant);
            var expected = 2;
            var actual = person.Gold;
            Assert.AreEqual(expected, actual);
        }

        private Merchant GenerateTestMerchant()
        {
            return new Merchant
            {
                Cost = 10,
                Active = false,
                WheatPrice = 2,
                StonePrice = 7,
            };
        }

        private Person GenerateTestPerson()
        {
            return new Person
            {
                Gold = 2,
            };
        }
    }
}

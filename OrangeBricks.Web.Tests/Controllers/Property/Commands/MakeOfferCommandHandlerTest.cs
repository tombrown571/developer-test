using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using OrangeBricks.Web.Controllers.Property.Commands;
using OrangeBricks.Web.Models;
using OrangeBricks.Web.Tests.Controllers.Property.Builders;

namespace OrangeBricks.Web.Tests.Controllers.Property.Commands
{
    [TestFixture]
    public class MakeOfferCommandHandlerTest
    {
        private MakeOfferCommandHandler _handler;
        private IOrangeBricksContext _context;
        private IDbSet<Models.Property> _mockProperties;
        private int _offerPropertyId = 382;

        [SetUp]
        public void Setup()
        {
            _context = Substitute.For<IOrangeBricksContext>();
            _context.Offers.Returns(Substitute.For<IDbSet<Models.Offer>>());
            var properties = new List<Models.Property>{
                new Models.Property { Id = _offerPropertyId, StreetName = "Orange Road", Description = "", IsListedForSale = true}
            }.AsQueryable();
            _mockProperties = Substitute.For<IDbSet<Models.Property>>();
            _mockProperties.Find(_offerPropertyId).Returns(properties.First());
            _context.Properties.Returns(_mockProperties);
            _handler = new MakeOfferCommandHandler(_context);
        }

        [Test]
        public void HandleShouldAddOffer()
        {
            // Arrange
            var command = new MakeOfferCommand();
            command.PropertyId = _offerPropertyId;

            //Act
            _handler.Handle(command);

            // Assert
            var propertyOffers = _mockProperties.Find(_offerPropertyId).Offers;
            Assert.AreEqual(1, propertyOffers.Count);
        }

        [Test]
        [ExpectedException(typeof(System.NullReferenceException))]
        public void HandleInvalidPropertyIdShouldThrowException()
        {
            // Arrange
            int invalidPropertyId = 8920;
            var command = new MakeOfferCommand() { PropertyId = invalidPropertyId};
            
            // Act
            _handler.Handle(command);
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using OrangeBricks.Web.Controllers.Property.Builders;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Tests.Controllers.Offers.Builders
{
    [TestFixture]
    public class MakeOfferViewModelBuilderTest
    {
        private IOrangeBricksContext _context;
        private IDbSet<Models.Property> _mockProperties;
        private int _offerPropertyId = 382;
        private string _buyerUserId = "buyer1";

        [SetUp]
        public void SetUp()
        {
            _context = Substitute.For<IOrangeBricksContext>();
            var properties = new List<Models.Property>{
                new Models.Property { Id = _offerPropertyId, StreetName = "Orange Road", Description = "", IsListedForSale = true}
            }.AsQueryable();
            _mockProperties = Substitute.For<IDbSet<Models.Property>>();
            _mockProperties.Find(_offerPropertyId).Returns(properties.First());
            _context.Properties.Returns(_mockProperties);
        }

        [Test]
        public void BuildMakeOfferViewModelRequiresValidPropertyId()
        {
            // Arrange
            MakeOfferViewModelBuilder builder = new MakeOfferViewModelBuilder(_context);

            // Act
            var model = builder.Build(_offerPropertyId);
            // Assert
            Assert.IsNotNull(model);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void BuildMakeOfferViewModelInvalidPropertyIdThrowsException()
        {
            // Arrange
            MakeOfferViewModelBuilder builder = new MakeOfferViewModelBuilder(_context);
            int invalidPropertyId = 7383;
            // Act
           builder.Build(invalidPropertyId);
        }
    }
}

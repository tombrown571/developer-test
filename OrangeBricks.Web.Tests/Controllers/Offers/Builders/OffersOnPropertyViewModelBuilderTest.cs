using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using OrangeBricks.Web.Controllers.Offers.Builders;
using OrangeBricks.Web.Controllers.Offers.ViewModels;
using OrangeBricks.Web.Controllers.Property.Builders;
using OrangeBricks.Web.Models;
using OrangeBricks.Web.Tests.Controllers.Property.Builders;

namespace OrangeBricks.Web.Tests.Controllers.Offers.Builders
{
    [TestFixture]
    public class OffersOnPropertyViewModelBuilderTest
    {
        private IOrangeBricksContext _context;

        [SetUp]
        public void Setup()
        {
            _context = Substitute.For<IOrangeBricksContext>();
        }

        [Test]
        public void BuildShouldReturnOffersOnPropertyHasOffersTrue()
        {
            // Arrange
            var builder = new OffersOnPropertyViewModelBuilder(_context);

            int hasOffersPropertyId = 55;

            var offers = new List<Models.Offer>
            {
                new Models.Offer {Amount = 25000, CreatedAt = new DateTime(2016, 11, 5), Status = OfferStatus.Pending},
                new Models.Offer {Amount = 35000, CreatedAt = new DateTime(2016, 11, 1), Status = OfferStatus.Pending}
            };
            var properties = new List<Models.Property>{
                new Models.Property { Id = hasOffersPropertyId, StreetName = "Offer Street", Description = "", IsListedForSale = true, Offers=offers},
                new Models.Property{ Id = 42, StreetName = "No Offers Street", Description = "", IsListedForSale = true}
            };

            var mockSet = Substitute.For<IDbSet<Models.Property>>()
                .Initialize(properties.AsQueryable());

            _context.Properties.Returns(mockSet);

            // Act
            var viewModel = builder.Build(hasOffersPropertyId);
            // Assert
            Assert.That(viewModel.HasOffers == true);

        }

        [Test]
        public void BuildShouldReturnNoOffersOnPropertyHasOffersFalse()
        {
            // Arrange
            var builder = new OffersOnPropertyViewModelBuilder(_context);

            int noOfferPropertyId = 55;

            var offers = new List<Models.Offer>
            {
                new Models.Offer {Amount = 25000, CreatedAt = new DateTime(2016, 11, 5), Status = OfferStatus.Pending},
                new Models.Offer {Amount = 35000, CreatedAt = new DateTime(2016, 11, 1), Status = OfferStatus.Pending}
            };
            var properties = new List<Models.Property>{
                new Models.Property { Id = 43, StreetName = "Offer Street", Description = "", IsListedForSale = true, Offers=offers},
                new Models.Property{ Id = noOfferPropertyId, StreetName = "No Offers Street", Description = "", IsListedForSale = true}
            };

            var mockSet = Substitute.For<IDbSet<Models.Property>>()
                .Initialize(properties.AsQueryable());

            _context.Properties.Returns(mockSet);

            // Act
            var viewModel = builder.Build(noOfferPropertyId);
            // Assert
            Assert.That(viewModel.HasOffers == false);


        }


    }
}

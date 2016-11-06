using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OrangeBricks.Web.Controllers.Viewing.ViewModels;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Viewing.Builders
{
    public class ViewingRequestViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public ViewingRequestViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public CreateViewingRequestViewModel Build(int propertyId, string buyerName, string sellerName)
        {

            Models.Property property = _context.Properties.First(p => p.Id == propertyId);

            string emailToSellerMessage =
                string.Format("Hello {0},{1},I would like to book a viewing of your property on {2}.{1}" +
                              "The best time for me would be{1}[ Add your suggested time here ]{1}Kind Regards{1}{3}",
                    sellerName, Environment.NewLine, property.StreetName, buyerName);

            var viewModel = new CreateViewingRequestViewModel()
            {
                BookViewingRequestMessage = emailToSellerMessage
            };

            return viewModel;
        }
    }
}
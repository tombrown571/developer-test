using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using OrangeBricks.Web.Controllers.Offers.ViewModels;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Offers.Builders
{
    public class BuyerOffersViewModelBuilder
    {

        private readonly IOrangeBricksContext _context;

        public BuyerOffersViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public BuyerOffersViewModel Build(string buyerId)
        {
            var offers = _context.Offers
                .Where(o => o.BuyerUserId == buyerId);


            var hasOffers = offers != null && offers.Count() > 0;
            return new BuyerOffersViewModel()
            {
                BuyerId = buyerId,
                HasMadeOffers = hasOffers,
                BuyerOffers = offers.Select(x=> new BuyerOfferOnPropertyViewModel
                {
                    Amount = x.Amount,
                    CreatedAt = x.CreatedAt,
                    Status = x.Status.ToString(),                   
                })
            };
        }

    }
}
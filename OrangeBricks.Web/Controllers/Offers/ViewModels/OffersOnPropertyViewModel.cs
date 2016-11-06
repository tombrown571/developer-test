using System;
using System.Collections.Generic;

namespace OrangeBricks.Web.Controllers.Offers.ViewModels
{
    public class OffersOnPropertyViewModel
    {
        public string PropertyType { get; set; }
        public int NumberOfBedrooms{ get; set; }
        public string StreetName { get; set; }
        public bool HasOffers { get; set; }
        public IEnumerable<OfferViewModel> Offers { get; set; }
        public int PropertyId { get; set; }
    }

    public class OfferViewModel
    {
        public int Id;
        public int Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsPending { get; set; }
        public string Status { get; set; }
    }


    public class BuyerOffersViewModel
    {
        public string BuyerId;

        public bool HasMadeOffers { get; set; }

        public IEnumerable<BuyerOfferOnPropertyViewModel> BuyerOffers { get; set; }
    }

    public class BuyerOfferOnPropertyViewModel
    {
        public int PropertyId { get; set; }
        public string PropertyType { get; set; }
        public int NumberOfBedrooms { get; set; }
        public string StreetName { get; set; }

        public int Amount { get; set; }

        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }


    }
}
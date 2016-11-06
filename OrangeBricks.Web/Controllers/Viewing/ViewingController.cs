using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrangeBricks.Web.Attributes;
using OrangeBricks.Web.Controllers.Viewing.Builders;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Viewing
{
    public class ViewingController : Controller
    {
        private readonly IOrangeBricksContext _context;

        public ViewingController(IOrangeBricksContext context)
        {
            _context = context;
        }
        [OrangeBricksAuthorize(Roles = "Buyer")]
        public ActionResult BookViewing(int id)
        {
            var builder = new ViewingRequestViewModelBuilder(_context);

            var buyerName = User.Identity.Name;
            // ToDo, get name/email of Seller
            var sellerName = "Seller";

            var viewModel = builder.Build(id, buyerName, sellerName);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult BookViewing(string emailMessage)
        {
            var buyerName = User.Identity.Name;

            var viewingRequest = new Models.Viewing()
            {
                BookViewingRequestMessage = emailMessage,
                BuyerUserId = buyerName
            };
            // TODO save the message 

            return RedirectToAction("Index", "Property");
        }

    }
}
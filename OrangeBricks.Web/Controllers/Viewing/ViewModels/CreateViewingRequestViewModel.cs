using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Viewing.ViewModels
{
    public class CreateViewingRequestViewModel
    {
        [Required]
        [Display(Name = "Request to Book a Viewing")]
        [DataType(DataType.MultilineText)]
        public string BookViewingRequestMessage { get; set; }
    }
}
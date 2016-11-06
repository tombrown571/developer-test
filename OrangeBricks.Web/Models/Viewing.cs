using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Models
{
    public class Viewing
    {
        [Key]
        public int Id { get; set; }

        public string BuyerUserId { get; set; }

        [ForeignKey("Property")]
        public int Property_Id { get; set; }
        public virtual Property Property { get; set; }

        public string BookViewingRequestMessage { get; set; }

    }
}
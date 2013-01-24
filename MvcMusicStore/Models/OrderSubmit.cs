using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMusicStore.Models
{
    public class OrderSubmit
    {
        public Order Order { get; set; }
        public IEnumerable<SelectListItem> ShippingMethods { get; set; }
        public string ShippingMethod { get; set; }
    }
}
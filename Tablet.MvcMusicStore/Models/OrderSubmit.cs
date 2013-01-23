using System.Collections.Generic;
using System.Web.Mvc;

namespace Tablet.MvcMusicStore.Models
{
    public class OrderSubmit
    {
        public Order Order { get; set; }
        public IEnumerable<SelectListItem> ShippingMethods { get; set; }
        public string ShippingMethod { get; set; }
    }
}
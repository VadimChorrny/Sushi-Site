using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace SushiSite.Models.ViewModel
{
    public class OrderViewModel
    {
        public Order Order { get; set; }
        public IEnumerable<SelectListItem> Foods { get; set; }
    }
}

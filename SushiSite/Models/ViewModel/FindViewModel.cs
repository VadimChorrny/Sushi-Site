using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace SushiSite.Models.ViewModel
{
    public class FindViewModel
    {
        public IEnumerable<Food> Foods { get; set; }
        public SelectList Categories { get; set; }
        public string SearchString { get; set; }
    }
}

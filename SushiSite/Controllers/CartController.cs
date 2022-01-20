using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SushiSite.Data;
using SushiSite.Helpers;
using SushiSite.Models;
using SushiSite.Models.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace SushiSite.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            List<Order> products = HttpContext.Session.GetObject<List<Order>>("ShoppingOrders");
            if (products == null)
                products = new List<Order>();

            int[] productIds = products.Select(i => i.FoodId).ToArray();

            CartListViewModel viewModel = new CartListViewModel()
            {
                Foods = _context.Foods.Where(c => productIds.Contains(c.Id))
            };

            return View(viewModel);
        }

        public IActionResult Confirm()
        {
            return View();
        }
    }
}

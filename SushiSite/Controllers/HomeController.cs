using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SushiSite.Data;
using SushiSite.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SushiSite.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string searchString)
        {
            var foods = from e in _context.Foods
                         select e;
            if (!String.IsNullOrEmpty(searchString))
            {
                foods = foods.Where(s => s.Title!.Contains(searchString));
            }
            return View(foods.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Contacts()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

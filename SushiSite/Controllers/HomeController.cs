﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using SushiSite.Data;
using SushiSite.Helpers;
using SushiSite.Models;
using SushiSite.Models.ViewModel;
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
            
            return View(foods);
        }

        public IActionResult FoodDetails(int id)
        {
            Food food = _context.Foods.Find(id);
            if (food == null) return NotFound();

            _context.Entry(food).Reference(nameof(Food.Category)).Load();

            bool isAddedToCart = false;
            List<ShoppingOrder> products = HttpContext.Session.GetObject<List<ShoppingOrder>>("ShoppingOrders");
            if (products != null)
            {
                if (products.FirstOrDefault(i => i.FoodId == id) != null)
                    isAddedToCart = true;
            }
            return View(new FoodDetailsViewModel() { Food = food, IsAddedToCart = isAddedToCart });
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Contacts()
        {
            return View();
        }
        public IActionResult AboutCreator() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

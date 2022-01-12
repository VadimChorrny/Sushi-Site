﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SushiSite.Data;
using SushiSite.Models;
using SushiSite.Models.ViewModel;
using System.Linq;

namespace SushiSite.Controllers
{
    public class OrderController : Controller
    {
        ApplicationDbContext _context;
        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Orders.ToList());
        }
        public IActionResult AddOrder()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddOrder(Order newOrder)
        {
            if (!ModelState.IsValid) return View();
            _context.Orders.Add(newOrder);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id <= 0) return NotFound();
            var orderToRemove = _context.Orders.Find(id);
            if (orderToRemove == null) return NotFound();
            _context.Orders.Remove(orderToRemove);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index)); // back to Index 
        }
        //public IActionResult ShowOrder(int? id)
        //{
        //    if (id == null || id <= 0) return NotFound();
        //    return View();
        //}
    }
}